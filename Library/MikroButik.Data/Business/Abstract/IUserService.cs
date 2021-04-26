using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroButik.Data.Business.Abstract
{
    public interface IUserService
    {
        ResponseModel<User> GetByEmail(string email);
        ResponseModel<List<OperationClaim>> GetClaims(User user);
    }
}
