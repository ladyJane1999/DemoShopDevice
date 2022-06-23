
using Microsoft.AspNetCore.Mvc;

using ProjectDemo.Model;
using ShopDevice.Services;
using ShopDevice.Models;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

           
                if (response == null)

                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("registration")]
        public IActionResult Registration(Users user)
        {
            var response = _userService.RegistrationUser(user);
            _userService.RegistrationUser(user);

            if (response == null)

                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpPost("product")]
      
        public IActionResult AddProduct([FromBody]Backet backet)
        {
            _userService.AddProducts(backet);
            return Ok(backet);
        }
    
        [HttpGet("backet")]
        public IActionResult GetBacket()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

    }
}
