using ProjectDemo.Model;

namespace ShopDevice.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Users user, string token)
        {
            Id = user.Id;
            FirstName = user.Email;
            LastName = user.Role;
            Token = token;
        }
    }
}
