using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopDevice.Repository;
using SiteShopCar.Data;
using SiteShopCar.Model;

namespace SiteShopCar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeDevicesController : Controller
    {
        private ICommonRepository<TypeDevice> typeDevicesRepository;
        public TypeDevicesController(ICommonRepository<TypeDevice> typeDevicesRepository)
        {
            this.typeDevicesRepository = typeDevicesRepository;
        }

        // GET: TypeDevices
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int limit)
        {
            return Ok(typeDevicesRepository.GetEntity(page, limit));
        }

        // GET: Devices/Details/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int? id)
        {

            return Ok(typeDevicesRepository.GetEntityByID(id));
        }

        // POST: Devices/Create
        [Authorize]
        [HttpPost]
   
        public async Task<IActionResult> Create([FromBody] TypeDevice typeDevice)
        {
       
            if (ModelState.IsValid)
            {
                typeDevicesRepository.InsertEntity(typeDevice);
                typeDevicesRepository.Save();
               
            }
            return Ok(new { message = "TypeDevice created" });
        }



        // POST: Devices/Edit/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] TypeDevice typeDevice)
        {

            if (ModelState.IsValid)
            {
                typeDevicesRepository.UpdateEntity(typeDevice);
                typeDevicesRepository.Save();
            }
            return Ok(new { message = "TypeDevice edited" });
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            typeDevicesRepository.DeleteEntity(id);
            typeDevicesRepository.Save();
            return Ok(new { message = "TypeDevice delited" });
        }
        protected override void Dispose(bool disposing)
        {
            typeDevicesRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
