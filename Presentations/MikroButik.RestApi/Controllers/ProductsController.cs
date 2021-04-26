using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikroButik.Common;
using MikroButik.Data.Business.Concrete;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.InputModels;
using Miktobutik.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MikroButik.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC Container -- Inversion of Control
        ProductManager _productManager;
        private readonly CategoryManager categoryManager;
        private readonly PhotoManager photoManager;
        private readonly ILogger<ProductsController> _logger;



        public ProductsController(ProductManager productManager, CategoryManager categoryManager,
            PhotoManager photoManager, ILogger<ProductsController> logger)
        {
            _productManager = productManager;
            this.photoManager = photoManager;
            this.categoryManager = categoryManager;
            this._logger = logger;
        }
        /// <summary>
        /// Tüm ürünleri listeler geri dönüş tipi Miktobutik.Models.ViewModels.ViewProductModel dir 
        /// <list type="bullet">
        /// <item > path = Products/GetAll </item>
        /// </list>
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<List<ViewProduct>> GetAll()
        {

            //Swagger
            //Dependency chain--
            var productResult = _productManager.GetAll();
            var photoResult = photoManager.GetAll();

            ResponseModel<List<ViewProduct>> responseModel = new ResponseModel<List<ViewProduct>>();
            responseModel.result = new List<ViewProduct>();
            foreach (var product in productResult.result)
            {
                foreach (var photo in photoResult.result)
                {
                    if (photo.ProductID == product.ProductID)
                    {
                        responseModel.result.Add(new ViewProduct { Product = product, Photo = photo });
                        responseModel.Success = true;
                    }

                }
            }
            return responseModel;

        }
        /// <summary>
        /// Categoriye göre listeleme 
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel<List<ViewProduct>> GetAllByCategoryId(long id)
        {
            //Swagger
            //Dependency chain--
            var productResult = _productManager.GetAllByCategoryId(id);
            var photoResult = photoManager.GetAll();

            ResponseModel<List<ViewProduct>> responseModel = new ResponseModel<List<ViewProduct>>();
            try
            {
                responseModel.result = new List<ViewProduct>();
                foreach (var product in productResult.result)
                {
                    foreach (var photo in photoResult.result)
                    {
                        if (photo.ProductID == product.ProductID)
                        {
                            responseModel.result.Add(new ViewProduct { Product = product, Photo = photo });
                            responseModel.Success = true;
                        }

                    }
                }
                _logger.LogInformation("Kategoriye göre ürünler listelendi");
                return responseModel;
            }
            catch (Exception ex)
            {

                responseModel.Success = false;
                responseModel.Message = ex.Message;
                _logger.LogError("Kategoriye göre listeleme başarısız");
            }


            return responseModel;

        }
        /// <summary>
        /// Fotoğrafları ile yeni bir ürün ekler aynı anda 1 den fazla fotoğraf yüklebilir.
        /// 
        /// 
        /// </summary>
        /// <returns type=""></returns>
        //[Obsolete("Metop fotoğraf yükleme işlemi henüz aktif diğil" ,true) ]
        [HttpPost]
        public ResponseModel<Product> Add([FromForm] InputProductModel inputProductModel)
        {
            //  var photoListFromForm = HttpContext.Request.Form.Files["photoList"];


            ResponseModel<Product> productResult = new ResponseModel<Product>();
            try
            {

                var photoResult = FileStorageHelper.UploadFile(inputProductModel.Photo);
                productResult = _productManager.Add(new Product { ProductName = inputProductModel.ProductName, ProductDescription = inputProductModel.ProductDescription, Price = inputProductModel.Price, UnitStock = inputProductModel.UnitStock, CategoryID = inputProductModel.CategoryID });
                var photoDBResult = photoManager.Add(new Photo { ProductID = productResult.result.ProductID, PhotoUrl = photoResult.result });

            }
            catch (Exception ex)
            {

                productResult.Success = false;
                productResult.Message = ex.Message;
            }


            return productResult;
        }
        /// <summary>
        /// Bir ürünü siler
        /// </summary>
        /// <returns type=""></returns>
        [HttpPost]
        public ResponseModel<Product> Delete([FromForm] Product product)
        {
            ResponseModel<Product> productResult = new ResponseModel<Product>();
            try
            {

                productResult = _productManager.Delete(product);
                var photo = photoManager.GetByProductId(productResult.result.ProductID);
                var photoResult = FileStorageHelper.DeleteFile(Path.Combine(Environment.CurrentDirectory, "wwwroot", photo.result.PhotoUrl));
                var photoDBResult = photoManager.Delete(new Photo
                {
                    PhotoID = photo.result.PhotoID,
                    PhotoUrl = photo.result.PhotoUrl,
                    ProductID = photo.result.ProductID,
                    isMain = photo.result.isMain
                });
                return productResult;

            }
            catch (Exception ex)
            {

                productResult.Success = false;
                productResult.Message = ex.Message;
            }
            return productResult;
        }
        /// <summary>
        /// Bir ürünü    günceller
        /// </summary>
        /// <returns type=""></returns>
        [HttpPut]
        public ResponseModel<Product> Update([FromForm] InputProductModel product)
        {
            ResponseModel<Product> productResult = new ResponseModel<Product>();
            try
            {

                productResult = _productManager.Update(new Product { CategoryID = product.CategoryID, ProductName = product.ProductName, UnitStock = product.UnitStock, Price = product.Price, ProductDescription = product.ProductDescription });
                var photo = photoManager.GetByProductId(productResult.result.ProductID);
                var photoResult = FileStorageHelper.UpdateFile(product.Photo, Path.Combine(Environment.CurrentDirectory, "wwwroot", photo.result.PhotoUrl));
                var photoDBResult = photoManager.Update(new Photo
                {
                    PhotoID = photo.result.PhotoID,
                    PhotoUrl = photoResult.result,
                    ProductID = photo.result.ProductID,
                    isMain = photo.result.isMain
                });
                return productResult;

            }
            catch (Exception ex)
            {

                productResult.Success = false;
                productResult.Message = ex.Message;
            }


            return productResult;
        }
        [AllowAnonymous]
        [HttpPut]
        public ResponseModel<ViewProduct> GetView(long id)
        {
            ResponseModel<ViewProduct> res = new ResponseModel<ViewProduct>();
            ViewProduct vp = new ViewProduct();
            vp.Product = _productManager.GetAll().result.FirstOrDefault(t => t.ProductID == id);
            vp.Photo = null;
            vp.Category = categoryManager.GetAll().result.FirstOrDefault(t => t.CategoryID == vp.Product.CategoryID);
            res.result = vp;
            return res;

        }
        /// <summary>
        /// Id'ye göre listeleme yapılabilir
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseModel<ViewProduct> GetById(int id)
        {
            ResponseModel<ViewProduct> productResult = new ResponseModel<ViewProduct>();

            try
            {

                productResult.result = new ViewProduct { Product = _productManager.GetById(id).result };
                var photoResult = photoManager.GetByProductId(id);
                productResult.result.Photo = photoResult.result;
                _logger.LogInformation("Ürün getirildi");
                return productResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                productResult.Success = false;
                productResult.Message = "Ürün getirilemedi, tekrar deneyiniz.";
            }
            return productResult;

        }

    }
}
