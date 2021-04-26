using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {

            return View(MikroButik.Admin.Models.ApiHelpers.GetCategories());
        }
        /// <summary>
        /// Yeni kategori açmak için view döndürür.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Yeni kategoriden açılacak modeli getirir. İşlemi yapar, listeye döner.
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// Silinecek kategorinin silme onay sayfasını getirir.
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            return View();
        }
        /// <summary>
        /// Kategoriden gelen modeli getirir.İşlemi yapar listeye döner.
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteConfirmed()
        {
            return View();
        }
        /// <summary>
        /// Düzenlenecek sayfayı getirir.
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }
        /// <summary>
        /// Düzenlenecek sayfada gelen modeli alır. İşlemi yapar listeye geri döner.
        /// </summary>
        /// <returns></returns>
        public IActionResult Update()
        {
            return View();
        }
    }
}
