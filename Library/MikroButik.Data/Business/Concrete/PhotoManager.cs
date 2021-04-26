using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MikroButik.Common;
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
    public class PhotoManager : ICRUDService<Photo>, IRegister 
    {

        IPhotoDAL _photoDAL;
        private readonly ILogger<PhotoManager> _logger;


        public PhotoManager(IPhotoDAL photoDAL, ILogger<PhotoManager> logger)
        {
            _photoDAL = photoDAL;
            _logger = logger;
        }


        ResponseModel<Photo> responseModel = new ResponseModel<Photo>();

        /// <summary>
        /// bu metod 2 parametre alır product api servisinin ekleme fonksiyonu tarafından kullanılmaktadır
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public ResponseModel<Photo> Add(Photo entity)
        {
            try
            {
                responseModel.result = entity;
                _logger.Log(LogLevel.Information, "Yeni fotoğraf eklendi");
               
    
                responseModel.Success = _photoDAL.Add(entity);
                return responseModel;


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message + "Fotoğraf yükleme hatası");
                responseModel.Success = false;
                responseModel.Message = ex.Message;
                return responseModel;
            }
        }
        //public ResponseModel<Photo> Update(Photo entity,IFormFile file)
        //{
        //    try
        //    {
        //        responseModel.result = entity;
        //        _logger.Log(LogLevel.Information, "Fotoğraf güncellendi");
        //        var result = FileStorageHelper.UpdateFile(file,entity.PhotoUrl);
        //        entity.PhotoUrl = result.Message;
        //        responseModel.Success = _photoDAL.Update(entity);
        //        return responseModel;
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError(ex, ex.Message + "Fotoğraf güncelleme hatası");
        //        responseModel.Success = false;
        //        responseModel.Message = ex.Message;
        //        return responseModel;
        //    }
        //}


        public ResponseModel<Photo> Delete(Photo entity)
        {
            try
            {

                responseModel.Success = _photoDAL.Delete(entity);
                if (responseModel.Success)
                {
                    FileStorageHelper.DeleteFile(entity.PhotoUrl);
                    return responseModel;
                }
                return responseModel;


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message + "Fotoğraf silme hatası");
                responseModel.Success = false;
                responseModel.Message = ex.Message;
                return responseModel;
            }

        }
        public ResponseModel<List<Photo>> GetById(int photoId)
        {
            return new ResponseModel<List<Photo>> { result =  _photoDAL.GetAll(p => p.PhotoID == photoId) };

        }
        public ResponseModel<Photo> GetByProductId(long productID)
        {
            return new ResponseModel<Photo> { result = _photoDAL.Get(p => p.ProductID == productID) };

        }

        public ResponseModel<List<Photo>> GetAll()
        {
            return new ResponseModel<List<Photo>> { result = _photoDAL.GetAll() };
        }

        public ResponseModel<Photo> GetSingle(int id)
        {
            return new ResponseModel<Photo> { result = _photoDAL.Get(x => x.PhotoID == id) };
        }

        public ResponseModel<Photo> Update(Photo entity)
        {
            try
            {
                responseModel.result = entity;
                _logger.Log(LogLevel.Information, "Fotoğraf güncellendi");


                responseModel.Success = _photoDAL.Update(entity);
                return responseModel;


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message + "Fotoğraf güncelleme hatası");
                responseModel.Success = false;
                responseModel.Message = ex.Message;
                return responseModel;
            }
        }

    }
}
