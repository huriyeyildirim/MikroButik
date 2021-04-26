using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.EntityModel
{
    public class Photo : IEntity
    {
        public long PhotoID { get; set; }
        public long ProductID { get; set; }
        public bool isMain { get; set; } = false;
        public string PhotoUrl { get; set; }

       // public Product Product { get; set; }
    }
}
