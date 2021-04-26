using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.ViewModels
{
    public class ViewOrder : IEntity
    {
        public long UserID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
