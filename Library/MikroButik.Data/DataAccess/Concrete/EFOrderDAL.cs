using MikroButik.Data.DataAccess.Abstract;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroButik.Data.DataAccess.Concrete
{
    public class EFOrderDAL : EFRepositoryBase<Order>, IOrderDAL
    {
        public EFOrderDAL(ApplicationDbContext context) : base(context)
        {
            //var testObject = Activator.CreateInstance<ICategoryDAL>();

        }
    }
}
