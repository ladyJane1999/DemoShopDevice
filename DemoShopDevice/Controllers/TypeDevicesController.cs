using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteShopCar.Data;
using SiteShopCar.Model;

namespace SiteShopCar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeDevicesController : Controller
    {
        private ITypeDevicesRepository typeDevicesRepository;

        public TypeDevicesController(ITypeDevicesRepository typeDevicesRepository)
        {
            this.typeDevicesRepository = typeDevicesRepository;
        }

        // GET: Devices
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(typeDevicesRepository.GetTypeDevices());
        }

        // GET: Devices/Details/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }

            return Ok(typeDevicesRepository.GetTypeDeviceByID(id));
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
   
        public async Task<IActionResult> Create([FromBody] TypeDevice typeDevice)
        {
            if (typeDevice.TypeDeviceId != null)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }
            if (ModelState.IsValid)
            {
                typeDevicesRepository.InsertTypeDevice(typeDevice);
                typeDevicesRepository.Save();
                return RedirectToAction(nameof(GetAll));
            }
            return RedirectToAction(nameof(GetAll));
        }



        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] TypeDevice typeDevice)
        {
            if (id != typeDevice.TypeDeviceId)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }

            if (ModelState.IsValid)
            {
                typeDevicesRepository.UpdateTypeDevice(typeDevice);
                typeDevicesRepository.Save();

                return RedirectToAction(nameof(GetAll));
            }
            return RedirectToAction(nameof(GetAll));
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }

            typeDevicesRepository.DeleteTypeDevice(id);
            typeDevicesRepository.Save();
            return RedirectToAction(nameof(GetAll));
        }
        protected override void Dispose(bool disposing)
        {
            typeDevicesRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
