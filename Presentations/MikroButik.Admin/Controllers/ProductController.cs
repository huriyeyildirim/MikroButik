using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(MikroButik.Admin.Models.ApiHelpers.GetProduct());
        }
        public IActionResult Product() 
        {
            return View();
        }
    }
}
