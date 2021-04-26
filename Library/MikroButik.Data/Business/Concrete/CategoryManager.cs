
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MikroButik.Data.DataAccess.Abstract;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MikroButik.Data.Business.Concrete
{
    public class CategoryManager : ICRUDService<Category>, IRegister, IFiltered<Category>
    {
        ICategoryDAL _categoryDAL;
        private readonly ILogger<CategoryManager> logger;
        //private readonly IHttpContextAccessor http;
        ResponseModel<Category> responseModel = new ResponseModel<Category>();


        public CategoryManager(ICategoryDAL categoryDAL, ILogger<CategoryManager> logger) //, IHttpContextAccessor http)
        {
            _categoryDAL = categoryDAL;
            this.logger = logger;
            //this.http = http;
        }

        /// <summary>
        /// YEni Kategori Eklersiniz. Resim Eklemek için 2. bir adım gereklidir.
        /// <list type="bullet">
        /// <item>İlk adımda ham veri günderin</item>
        /// <item>2. adımda farklı bir endpoint üzerinden Resim için BYTE[] data gönderin</item>
        /// </list>
        /// </summary>
        /// <param name="entity">Category Türüne convert edilmiş veri tipi gönderin.</param>
        /// <returns></returns>
        public ResponseModel<Category> Add(Category entity)
        {
            try
            {
                responseModel.Success = _categoryDAL.Add(entity);
                responseModel.result = entity;
                //  logger.LogInformation("Yeni Kategori Eklendi {data}, {user}", entity, http.HttpContext.User);
                return responseModel;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + "Kritik Veri işleme hatası");
                responseModel.Success = false;
                responseModel.Message = "Kritik veri işleme hatası";
                return responseModel;
            }


        }

        public ResponseModel<Category> Delete(Category entity)
        {

            responseModel.Success = _categoryDAL.Delete(entity);
            responseModel.Message = "Kategori Silinid";
            return responseModel;

        }
        public ResponseModel<List<Category>> GetAll()
        {

            return new ResponseModel<List<Category>>() { result = _categoryDAL.GetAll(), Success = true, Message = "Kategoriler Listelendi" };


        }

        public ResponseModel<Category> Update(Category entity)
        {
            responseModel.Success = _categoryDAL.Update(entity);
            responseModel.Message = "Kategori güncellendi";
            return responseModel;
        }

        public ResponseModel<List<Category>> Query(Expression<Func<Category, bool>> filter = null)
        {
            ResponseModel<List<Category>> responseModel = new ResponseModel<List<Category>>();
            responseModel.result = _categoryDAL.GetAll(filter);
            return responseModel;            
        }

        public ResponseModel<Category> GetById(long id)
        {
            responseModel.result = _categoryDAL.Get(c=>c.CategoryID==id);
            return responseModel;
        }
    }
}
