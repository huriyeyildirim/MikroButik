using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.ViewModels
{
    public class ViewCategory : IEntity
    {
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }

}
