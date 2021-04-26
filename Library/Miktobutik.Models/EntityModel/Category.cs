using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.EntityModel
{
    public class Category : IEntity
    {
        [Key]
        public long CategoryID { get; set; }

         
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Keywords { get; set; }
        public bool ActiveState { get; set; }

        // [NotMapped]
        // public ICollection<Product> Products { get; set; }

    }
}
