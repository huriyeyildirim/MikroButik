using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]

    public class AuthController : ControllerBase
    {
        private AuthManager _authManager;
        private readonly ILogger<AuthController> logger;


        public AuthController(AuthManager authManager, ILogger<AuthController> logger)
        {
            _authManager = authManager;
            this.logger = logger;
        }
        /// <summary>
        /// Kayıt olmuş kullanıcı giriş yapabilir
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel<User> Login([FromBody] InputLoginModel user)
        {
            var result = new ResponseModel<User>();
            var x = Guid.NewGuid().ToString();
            try
            {
                if (ModelState.IsValid)
                {
                    User NewCat = new User()
                    {
                        Email = user.Email,
                        PasswordSalt = user.Password
                        //HashedPassword = AuthManager.HashingHelper.CreatePasswordHash(user.Password, x)
                    };
                    result = _authManager.Login(user);
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
