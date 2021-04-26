using Microsoft.EntityFrameworkCore;
using MikroButik.Data.Business;
using MikroButik.Data.DataAccess.Abstract;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroButik.Data.DataAccess.Concrete
{
    public class EFCategoryDAL : EFRepositoryBase<Category>, ICategoryDAL
    {
        public EFCategoryDAL(ApplicationDbContext context) : base(context)
        {
            //var testObject = Activator.CreateInstance<ICategoryDAL>();

        }
    }
}
