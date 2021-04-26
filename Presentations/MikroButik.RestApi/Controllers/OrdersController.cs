using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikroButik.Data.Business.Concrete;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class OrdersController : ControllerBase
    {
        OrderManager _orderManager;
        private readonly ILogger<OrdersController> logger;
        public OrdersController(OrderManager orderManager, ILogger<OrdersController> logger)
        {
            _orderManager = orderManager;
            this.logger = logger;
        }

        /// <summary>
        /// Tüm siparişleri listeler
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<List<Order>> GetAll()
        {
            //Swagger
            //Dependency chain--
            var result = _orderManager.GetAll();
            return result;
        }
        /// <summary>
        /// Yeni bir sipariş ekler
        /// </summary>
        /// <returns type=""></returns>
        [HttpPost]
        public ResponseModel<Order> Add([FromBody] Miktobutik.Models.InputModels.InputOrder order)
        {
            var result = new ResponseModel<Order>();
            try
            {
                if (ModelState.IsValid)
                {
                    Order NewCat = new Order()
                    {
                        OrderDate = order.OrderDate,
                        UserID = order.UserID,
                        ProductID = order.ProductID

                    };
                    result = _orderManager.Add(NewCat);
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
        /// Bir siparişi siler
        /// </summary>
        /// <returns type=""></returns>
        [HttpPost]
        public ResponseModel<Order> Delete(Order order)
        {
            ResponseModel<Order> result = new ResponseModel<Order>();
            try
            {
                if (ModelState.IsValid)
                {
                    result = _orderManager.Delete(order);
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
        /// Bir siparişi günceller
        /// </summary>
        /// <returns type=""></returns>
        [HttpPut]
        public ResponseModel<Order> Update(Order order)
        {
            ResponseModel<Order> result = new ResponseModel<Order>();
            try
            {
                if (ModelState.IsValid)
                {
                    result = _orderManager.Update(order);
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
        public ResponseModel<Order> GetById(long id)
        {
            ResponseModel<Order> responseModel = new ResponseModel<Order>();
            try
            {
                responseModel = _orderManager.GetById(id);
                responseModel.Success = true;
                logger.LogInformation("");
                return responseModel;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                responseModel.Success = false;
                responseModel.Message = "";

            }
            return responseModel;
        }
        /// <summary>
        /// Product Id'ye göre listeleme yapılabilir
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<List<Order>> GetByProductId(long id)
        {
            ResponseModel<List<Order>> responseModel = new ResponseModel<List<Order>>();
            try
            {
                responseModel = _orderManager.GetByProductId(id);
                responseModel.Success = true;
                logger.LogInformation("");
                return responseModel;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                responseModel.Success = false;
                responseModel.Message = "";
            }
            return responseModel;
        }
        /// <summary>
        /// User Id'ye göre listeleme yapılabilir
        /// </summary>
        /// <returns type=""></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseModel<List<Order>> GetByUserId(long id)
        {
            ResponseModel<List<Order>> responseModel = new ResponseModel<List<Order>>();
            try
            {
                responseModel = _orderManager.GetByUserId(id);
                responseModel.Success = true;
                logger.LogInformation("");
                return responseModel;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                responseModel.Success = false;
                responseModel.Message = "";
            }
            return responseModel;
        }

    }
}
