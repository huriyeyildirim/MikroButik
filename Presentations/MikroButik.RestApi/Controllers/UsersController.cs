using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikroButik.Data.Business.Concrete;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserManager _userManager;
        private readonly ILogger<UsersController> logger;

        public UsersController(UserManager userManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            this.logger = logger;
        }

        /// <summary>
        /// Tüm Kullanıcıları listeler
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<List<User>> GetAll()
        {
            var result = _userManager.GetAll();
            return result;
        }
        /// <summary>
        /// Yeni bir kullanıcı ekler
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel<User> Add([FromBody] InputRegisterModel user)
        {

            var result = new ResponseModel<User>();
            var x = Guid.NewGuid().ToString();
            try
            {
                var userExists = _userManager.UserExists(user.Email);
                if (!userExists.Success)
                {
                    if (ModelState.IsValid)
                    {
                        User NewCat = new User()
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            PasswordSalt = x,
                            Phone = user.Phone,
                            HashedPassword = AuthManager.HashingHelper.CreatePasswordHash(user.Password, x)
                        };
                        result = _userManager.Add(NewCat);
                    }
                    else
                    {
                        result.Success = false;
                        result.result = null;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// Bir kullanıcıyı siler
        /// </summary>
        /// <returns type=""></returns>
        [HttpPost]
        public ResponseModel<User> Delete(User user)
        {
            ResponseModel<User> result = new ResponseModel<User>();
            try
            {
                if (ModelState.IsValid)
                {
                    result = _userManager.Delete(user);
                }
                else
                {
                    result.Success = false;
                    result.result = null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// Bir kullanıcıyı günceller
        /// </summary>
        /// <returns type=""></returns>
        [HttpPut]
        public ResponseModel<User> Update(User user)
        {
            ResponseModel<User> result = new ResponseModel<User>();
            try
            {
                if (ModelState.IsValid)
                {
                    result = _userManager.Update(user);
                }
                else
                {
                    result.Success = false;
                    result.result = null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
