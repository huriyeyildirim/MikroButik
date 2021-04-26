using Miktobutik.Models.EntityModel;
using Miktobutik.Models.EntityModel.Abstract;
using System.Collections.Generic;

namespace Miktobutik.Models.ViewModels
{
    public class ViewProduct : IEntity
    {

        public Product Product { get; set; }
        public Photo Photo{ get; set; }

        public Category Category { get; set; }

    }

}
