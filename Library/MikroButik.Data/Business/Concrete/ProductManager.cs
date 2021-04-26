using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class ProductManager : ICRUDService<Product>, IRegister ,IFiltered<Product>
    {
        IProductDAL _productDAL;
        ResponseModel<Product> responseModel = new ResponseModel<Product>();
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public ResponseModel<Product> Add(Product entity)
        {
            responseModel.Success = _productDAL.Add(entity);
            responseModel.result = entity;
            return responseModel;
        }

        public ResponseModel<Product> Delete(Product entity)
        {
            responseModel.Success = _productDAL.Delete(entity);
            responseModel.result = entity;
            return responseModel;
        }

        public ResponseModel<List<Product>> GetAll()
        {
            return new ResponseModel<List<Product>>() { result = _productDAL.GetAll() };
            
        }

        public ResponseModel<Product> GetById(long id)
        {
            return new ResponseModel<Product>() { result = _productDAL.Get(x => x.ProductID == id) };
        }

        public ResponseModel<List<Product>> GetAllByCategoryId(long id)
        {
            return new ResponseModel<List<Product>>() { result = _productDAL.GetAll(x => x.CategoryID == id) };
        }

        //public ResponseModel<Product> GetById(long id)
        //{
        //    responseModel.result = _productDAL.GetAll(t => t.ProductID == id).FirstOrDefault();
        //    return responseModel;
        //}

        public ResponseModel<Product> Update(Product entity)
        {
            responseModel.Success = _productDAL.Update(entity);
            responseModel.result = entity;
            return responseModel;
        }

        ResponseModel<List<Product>> IFiltered<Product>.Query(Expression<Func<Product, bool>> filter)
        {
            ResponseModel<List<Product>> responseModel = new ResponseModel<List<Product>>();
            responseModel.result = _productDAL.GetAll(filter);
            return responseModel;
        }
    }
}
