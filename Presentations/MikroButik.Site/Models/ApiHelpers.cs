using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Site.Models
{
    public static class ApiHelpers
    {     
        public static ResponseModel<List<Category>> GetCategories() {    
           var cli = new MikroButik.Common.ApiClient();  
           return cli.GetData<ResponseModel<List<Category>>>(Models.Paths.AllCategories);
        }

        public static ResponseModel<Category> AddCategories(Miktobutik.Models.InputModels.InputCategory model)
        {
            var cli = new MikroButik.Common.ApiClient();
            var data = cli.PostData<ResponseModel<Category>>(Models.Paths.AddCategory, model);   
            return data;
        }

        public static ResponseModel<List<Product>> GetProduct() 
        {
            var cli = new MikroButik.Common.ApiClient();
            return cli.GetData<ResponseModel<List<Product>>>(Models.Paths.AllProducts);
        }
        public static ResponseModel<Miktobutik.Models.ViewModels.ViewProduct> GetProductById(long Id)
        {
            var cli = new MikroButik.Common.ApiClient();
            return cli.GetData<ResponseModel<Miktobutik.Models.ViewModels.ViewProduct>>(Models.Paths.SingleProducts+Id);
        }
        public static ResponseModel<Product> AddProduct(Miktobutik.Models.InputModels.InputProductModel model)
        {
            var cli = new MikroButik.Common.ApiClient();
            var data = cli.PostData<ResponseModel<Product>>(Models.Paths.AddProducts, model);
            return data;
        }

        public static ResponseModel<List<Order>> GetOrder()
        {
            var cli = new MikroButik.Common.ApiClient();
            return cli.GetData<ResponseModel<List<Order>>>(Models.Paths.AllOrders);
        }
        public static ResponseModel<Order> AddOrder(Miktobutik.Models.InputModels.InputOrder model)
        {
            var cli = new MikroButik.Common.ApiClient();
            var data = cli.PostData<ResponseModel<Order>>(Models.Paths.AddOrders, model);
            return data;
        }

        public static ResponseModel<List<User>> GetUsers()
        {
            var cli = new MikroButik.Common.ApiClient();
            return cli.GetData<ResponseModel<List<User>>>(Models.Paths.AllUsers);
        }
        public static ResponseModel<User> AddUser(Miktobutik.Models.InputModels.InputUser model)
        {
            var cli = new MikroButik.Common.ApiClient();
            var data = cli.PostData<ResponseModel<User>>(Models.Paths.AddUsers, model);
            return data;
        }
    }
}
