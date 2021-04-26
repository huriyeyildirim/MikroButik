using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikroButik.Data.Business.Concrete;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        CategoryManager _categoryManager;
        private readonly ILogger<CategoriesController> logger;

        public CategoriesController(CategoryManager categoryManager, ILogger<CategoriesController> logger)
        {
            _categoryManager = categoryManager;
            this.logger = logger;
        }

        /// <summary>
        /// Tüm kategorileri listeler
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<List<Category>> GetAll()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "Name");
            var result = _categoryManager.GetAll();
            return result;
        }
        /// <summary>
        /// Yeni bir kategori ekler
        /// </summary>
        /// <returns type=""></returns>
        [HttpPost]
        public ResponseModel<Category> Add([FromBody] Miktobutik.Models.InputModels.InputCategory category)
        {
            var result = new ResponseModel<Category>();
            try
            {
                if (ModelState.IsValid)
                {
                    Category NewCat = new Category()
                    {
                        Name = category.Name,
                        ActiveState = category.ActiveState,
                        Description = category.Description,
                        Keywords = category.Keywords
                    };
                    result = _categoryManager.Add(NewCat);
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
        /// Bir kategoriyi siler
        /// </summary>
        /// <returns type=""></returns>
        [HttpPost]
        public ResponseModel<Category> Delete(Category category)
        {
            ResponseModel<Category> result = new ResponseModel<Category>();
            try
            {
                if (ModelState.IsValid)
                {
                    result = _categoryManager.Delete(category);
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
        /// Bir kategoriyi günceller
        /// </summary>
        /// <returns type=""></returns>
        [HttpPut]
        public ResponseModel<Category> Update(Category category)
        {
            ResponseModel<Category> result = new ResponseModel<Category>();
            try
            {
                if (ModelState.IsValid)
                {
                    result = _categoryManager.Update(category);
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
        /// Id'ye göre listeleme yapılabilir
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<Category> GetById(long id)
        {
            ResponseModel<Category> responseModel = new ResponseModel<Category>();
            try
            {
                responseModel = _categoryManager.GetById(id);
                logger.LogInformation("Kategori GetById başarılı");
                return responseModel;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                responseModel.Success = false;
                responseModel.Message = "Kategori GetById başarısız";
            }

            return responseModel;
        }




    }
}
