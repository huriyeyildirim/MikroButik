using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikroButik.Site.Models;
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIdentityServerInteractionService _interaction;

        public HomeController(ILogger<HomeController> logger, IIdentityServerInteractionService interaction)
        {
            _logger = logger;
            _interaction = interaction;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            ///GETIR
             var xx = Models.ApiHelpers.GetCategories();
            var pro = Models.ApiHelpers.GetProduct();
            var ord = Models.ApiHelpers.GetOrder();
            var usr = Models.ApiHelpers.GetUsers();

            //if (x.Success)
            //{    
            //    return View(x);
            //}
            //else {
            //    return RedirectToAction("error", "home");
            //}  

            ///GÖNDER
            ///
            try
            {
                _logger.LogInformation("Kategoriler Alındı IP:>", Request.HttpContext.Connection.RemoteIpAddress.ToString());
                var x = Models.ApiHelpers.AddCategories(new Miktobutik.Models.InputModels.InputCategory { ActiveState = true, Description = "Açıklama", Name = "Adı falan", Keywords = "a,a,a,a" });
                return View(xx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("~/views/shared/error500.cshtml");
            }

            try
            {
                _logger.LogInformation("Ürünler Alındı IP:>", Request.HttpContext.Connection.RemoteIpAddress.ToString());
                var x = Models.ApiHelpers.AddProduct(new Miktobutik.Models.InputModels.InputProductModel{  ProductName = "Açıklama", CategoryID =4 , Price=3, ProductDescription="djk", UnitStock=2 });
                return View(pro);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("~/views/shared/error500.cshtml");
            }
            try
            {
                _logger.LogInformation("siparişler Alındı IP:>", Request.HttpContext.Connection.RemoteIpAddress.ToString());
                var x = Models.ApiHelpers.AddOrder(new Miktobutik.Models.InputModels.InputOrder { UserID = 5 });
                return View(ord);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("~/views/shared/error500.cshtml");
            }

            try
            {
                _logger.LogInformation("Kullanıcılar Alındı IP:>", Request.HttpContext.Connection.RemoteIpAddress.ToString());
                var x = Models.ApiHelpers.AddUser(new Miktobutik.Models.InputModels.InputUser {  FirstName = "Açıklama", LastName = "rgrt", Password = "tgdf", Email="@" });
                return View(usr);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("~/views/shared/error500.cshtml");
            }
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string errorId)
        {
            var message = _interaction.GetErrorContextAsync(errorId).Result;
            return View(new ErrorViewModel { RequestId = message.ErrorDescription });
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
