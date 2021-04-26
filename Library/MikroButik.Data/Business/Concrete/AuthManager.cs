using Microsoft.AspNetCore.Mvc;
using MikroButik.Common;
using MikroButik.Data.Business.Abstract;
using MikroButik.Data.DataAccess.Abstract;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MikroButik.Data.Business.Concrete
{
    public class AuthManager : IAuthService, IRegister
    {
        private IUserDAL _userDal;
        private UserManager _userService;


        ResponseModel<User> responseModel = new ResponseModel<User>();

        public AuthManager(IUserDAL userDAL, UserManager userService)
        {
            _userDal = userDAL;

            _userService = userService;
        }

        public ResponseModel<User> Login(InputLoginModel inputLoginModel)
        {
            var userToCheck = _userService.GetByEmail(inputLoginModel.Email);
            if (userToCheck == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Kullanıcı adı veya parola hatalı";
            }
            if (userToCheck.result == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Kullanıcı adı veya parola hatalı";
                return responseModel;
            }
            if (HashingHelper.CreatePasswordHash(inputLoginModel.Password, userToCheck.result.PasswordSalt) != userToCheck.result.HashedPassword)
            {
                responseModel.Message = "Login işlemi başarılı";
            }
            if (userToCheck.Success)
            {

                userToCheck.result.PasswordSalt = null;
                userToCheck.result.HashedPassword = null;
                responseModel.Success = true;
                responseModel.result = userToCheck.result;
            }
            return responseModel;


        }

        public ResponseModel<User> Register(InputRegisterModel inputRegisterModel, string password)
        {
            string passwordHash, passwordSalt;
            // HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = inputRegisterModel.Email,
                FirstName = inputRegisterModel.FirstName,
                LastName = inputRegisterModel.LastName,
                Phone = inputRegisterModel.Phone,

            };
            responseModel.Success = _userDal.Add(user);
            return responseModel;

        }

        public ResponseModel<User> UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                responseModel.Message = "Kullanıcı Mevcut";
            }
            return responseModel;
        }
        public class HashingHelper
        {
            public static string CreatePasswordHash
                (string password, string passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {

                    return Encoding.UTF8.GetString(hmac.ComputeHash(Encoding.UTF8.GetBytes(password + passwordSalt)));

                }

            }


        }
    }
}

