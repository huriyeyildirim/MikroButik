using Microsoft.AspNetCore.Http;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.InputModels
{
    public class InputProductModel
    {
        public long CategoryID { get; set; }

        [MaxLength(200, ErrorMessage = "Ürün ismi maksimum 200 karakter olmalı")]
        public string ProductName { get; set; }

        [MaxLength(2000, ErrorMessage = "Ürün açıklaması maksimum 2000 karakter olmalı")]
        public string ProductDescription { get; set; }
        public int UnitStock { get; set; }

        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }

    }
}
