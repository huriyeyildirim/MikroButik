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
    public class OrderManager : ICRUDService<Order>, IRegister, IFiltered<Order>
    {
        IOrderDAL _orderDAL;
        private readonly ILogger<OrderManager> logger;
        ResponseModel<Order> responseModel = new ResponseModel<Order>();
        public OrderManager(IOrderDAL orderDAL, ILogger<OrderManager> logger)
        {
            _orderDAL = orderDAL;
            this.logger = logger;
        }

        public ResponseModel<Order> Add(Order entity)
        {
            try
            {
                responseModel.Success = _orderDAL.Add(entity);
                responseModel.result = entity;
                return responseModel;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + "Kritik Veri işleme hatası");
                responseModel.Success = false;
                responseModel.Message = ex.Message;
                return responseModel;
            }

        }

        public ResponseModel<Order> Delete(Order entity)
        {
            responseModel.Success = _orderDAL.Delete(entity);
            responseModel.Message = "Sipariş Silindi";
            return responseModel;
        }

        public ResponseModel<List<Order>> GetAll()
        {
            return new ResponseModel<List<Order>>() { result = _orderDAL.GetAll(), Success = true, Message = "Sipariş Listelendi" };
        }

        public ResponseModel<Order> Update(Order entity)
        {
            responseModel.Success = _orderDAL.Update(entity);
            responseModel.Message = "Sipariş Güncellendi";
            return responseModel;
        }

        public ResponseModel<List<Order>> Query(Expression<Func<Order, bool>> filter = null)
        {
            ResponseModel<List<Order>> responseModel = new ResponseModel<List<Order>>();
            responseModel.result = _orderDAL.GetAll();
            return responseModel;
        }

        public ResponseModel<Order> GetById(long id)
        {         
            responseModel.result = _orderDAL.Get(o => o.OrderID == id);
            return responseModel;
        }

        public ResponseModel<List<Order>> GetByUserId(long id)
        {
            ResponseModel<List<Order>> responseModel = new ResponseModel<List<Order>>();
            responseModel.result = _orderDAL.GetAll(o => o.UserID == id);
            return responseModel;
        }

        public ResponseModel<List<Order>> GetByProductId(long id)
        {
            ResponseModel<List<Order>> responseModel = new ResponseModel<List<Order>>();
            responseModel.result = _orderDAL.GetAll(o => o.ProductID == id);
            return responseModel;
        }
    }
}
