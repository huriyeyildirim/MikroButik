using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktobutik.Models.EntityModel
{
    public class User : IEntity
    {
        [Key]
        public long UserID { get; set; }
        // public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        // public Photo Photo { get; set; }
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }

        //  public ICollection<Order> Orders { get; set; }
        // public ICollection<Product> Products { get; set; }
    }
}
