using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.InputModels
{
    public class InputCategory:IEntity
    {

        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [MaxLength(250,ErrorMessage ="En fazla 250 karakterlik veri igirişi yapılabilir.")]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Keywords { get; set; }
        public bool ActiveState { get; set; }
    }
}
