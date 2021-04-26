using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Site.Controllers
{
    public class CategoriesController : Controller
    {

        [Route("c-{id}")]
        public IActionResult Index(long id)
        {
            
            return View(MikroButik.Site.Models.ApiHelpers.GetProduct());
        }
      
    }
}
