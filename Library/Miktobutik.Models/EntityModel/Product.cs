using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.EntityModel
{

    public class Product : IEntity
    {

        public Product()
        {
//#if DEBUG
//            ProductID = 20;
//            ProductName = "abibas";

//#endif
        }
        [Key]
        public long ProductID { get; set; }
        public long CategoryID { get; set; }

        [MaxLength(200, ErrorMessage = "Ürün ismi maksimum 200 karakter olmalı")]
        public string ProductName { get; set; }

        [MaxLength(2000, ErrorMessage = "Ürün açıklaması maksimum 2000 karakter olmalı")]
        public string ProductDescription { get; set; }
        public int UnitStock { get; set; }

        public decimal Price { get; set; }

        // public ICollection<Photo> Photos { get; set; }
        // public Category Category { get; set; }
    }
}
