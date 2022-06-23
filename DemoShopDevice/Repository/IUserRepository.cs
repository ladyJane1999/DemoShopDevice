using ProjectDemo.Model;
using ShopDevice.Models;

namespace DemoShopDevice.Repository
{
    public interface IUserRepository : IDisposable
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        AuthenticateResponse RegistrationUser(Users user);
        IEnumerable<Users> GetAll();
        Users GetById(int? id);
        void AddProducts(Backet backet);
    }
}
