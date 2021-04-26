using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.EntityModel
{
    public class Order : IEntity
    {
        public Order ()
        {
            OrderDate = DateTime.Now;
        }
        public long OrderID { get; set; }
        public long ProductID { get; set; }
        public long UserID { get; set; }
        public DateTime OrderDate { get; set; }

       // [NotMapped]
       // public User User { get; set; }
    }
}
