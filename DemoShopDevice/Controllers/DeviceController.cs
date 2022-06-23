using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using ShopDevice.Repository;
using SiteShopCar.Data;
using SiteShopCar.Model;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SiteShopCar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : Controller
    {
     
        private IDeviceRepository<Device> deviceRepository;

        private readonly DbApplicationContext _context;

        public DeviceController(IDeviceRepository<Device> deviceRepository, DbApplicationContext context)
        {
            this.deviceRepository = deviceRepository;
            _context = context;
        }

        // GET: Devices
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int limit)
        {
            return Ok(deviceRepository.GetDevices(page, limit));
        }

        // GET: Devices/Details/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int? id)
        {

            return Ok(deviceRepository.GetDeviceByID(id));
        }

        // POST: Devices/Create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Device device)
        {

            if (ModelState.IsValid)
            {
                deviceRepository.InsertDevice(device);
                deviceRepository.Save();

            }
           
            return Ok(new { message = "User created" });
        }



        // POST: Devices/Edit/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Device device)
        {

            if (ModelState.IsValid)
            {
                deviceRepository.UpdateDevice(device);
                deviceRepository.Save();
            }
            return Ok(new { message = "User updated" });
        }

        // POST: Devices/Delete/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        
            deviceRepository.DeleteDevice(id);
            deviceRepository.Save();
            return Ok(new { message = "User deleted" });
        }
        protected override void Dispose(bool disposing)
        {
            deviceRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
