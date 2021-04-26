
using Miktobutik.Models;
using Miktobutik.Models.EntityModel;
using Miktobutik.Models.InputModels;


namespace MikroButik.Data.Business
{
    public interface IAuthService
    {
        ResponseModel<User> Register(InputRegisterModel inputRegisterModel, string password);
        ResponseModel<User> Login(InputLoginModel inputLoginModel);
        ResponseModel<User> UserExists(string email);
    }
}
