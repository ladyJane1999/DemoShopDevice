using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectDemo.Model;
using ShopDevice.Helpers;
using ShopDevice.Models;
using SiteShopCar.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopDevice.Services
{ 
public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Users> GetAll();
    Users GetById(int id);
     void AddProducts(Backet backet);
    AuthenticateResponse RegistrationUser(Users user);
    }

public class UserService : IUserService
{

    private readonly AppSettings _appSettings;

        private readonly DbApplicationContext _context;

        public UserService(IOptions<AppSettings> appSettings, DbApplicationContext context)
    {
        _appSettings = appSettings.Value;
            _context = context;
        }

       
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

        public AuthenticateResponse RegistrationUser(Users user)
        {
            if (user == null) return null;

            var userNew = _context.Users.Add(user);

            var token = generateJwtToken(userNew.Entity);

            return new AuthenticateResponse(user, token);
        }

        public void AddProducts(Backet backet)
        {
            _context.Backet.Add(backet);
        }

    public IEnumerable<Users> GetAll()
    {
        return _context.Users.ToList();
    }

    public Users GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string generateJwtToken(Users user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
}
