using MikroButik.Data.Business.Abstract;
using MikroButik.Data.DataAccess.Abstract;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MikroButik.Data.Business.Concrete.AuthManager;

namespace MikroButik.Data.Business.Concrete
{
    public class UserManager : ICRUDService<User>, IRegister
    {
        IUserDAL _userDAL;


        ResponseModel<User> responseModel = new ResponseModel<User>();
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public ResponseModel<User> Add(User entity)
        {
            responseModel.Success = _userDAL.Add(entity);
            return responseModel;
        }

        public ResponseModel<User> Delete(User entity)
        {
            responseModel.Success = _userDAL.Delete(entity);
            return responseModel;
        }

        public ResponseModel<List<User>> GetAll()
        {
            return new ResponseModel<List<User>>() { result = _userDAL.GetAll() };
        }

        public ResponseModel<User> Update(User entity)
        {
            responseModel.Success = _userDAL.Update(entity);
            return responseModel;
        }
        public ResponseModel<User> GetByEmail(string email)
        {
            responseModel.result = _userDAL.Get(x => x.Email == email);
            if (responseModel.result != null) {
                responseModel.Success = true;
            } 
            return responseModel;
        }

        public ResponseModel<User> UserExists(string email)
        {
            if (GetByEmail(email) != null)
            {
                responseModel.Message = "Kullanıcı Mevcut";
            }
            return responseModel;
        }

        //public ResponseModel<User> Login(InputLoginModel inputLoginModel)
        //{
        //    var userToCheck = GetByEmail(inputLoginModel.Email);
        //    if (!userToCheck.Success)
        //    {
        //        responseModel.Success = false;
        //        responseModel.Message = "Kullanıcı adı veya parola hatalı";
        //    }
        //// Hata Hashed password
        //    if (HashingHelper.CreatePasswordHash(inputLoginModel.Password, userToCheck.result.PasswordSalt) != userToCheck.result.HashedPassword)
        //    {
        //        responseModel.Message = "Kullanıcı bilgilerini hatalı girdiniz";
        //    }
        //    if (userToCheck.Success)
        //    {

        //        userToCheck.result.PasswordSalt = null;
        //        userToCheck.result.HashedPassword = null;
        //        responseModel.Success = true;
        //        responseModel.result = userToCheck.result;
        //    }
        //    return responseModel;


        //}


        public ResponseModel<List<OperationClaim>> GetClaims(User user)
        {
            return GetClaims(user);
        }
    }
}


