using Miktobutik.Models.EntityModel;
using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.InputModels
{
    public class InputOrder : IEntity 
    {

        public InputOrder()
        {
            OrderDate = DateTime.Now;
        }
        public long UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public long ProductID { get; set; }
    }
}
