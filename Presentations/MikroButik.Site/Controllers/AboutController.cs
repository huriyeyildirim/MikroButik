using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Site.Controllers
{
    public class AboutController : Controller
    {

        [Route("/bizkimiz")]
        public IActionResult Index(long id)
        {
            return View();
        }
        public IActionResult About()
        {
            
            return View();
        }  
    }
}
