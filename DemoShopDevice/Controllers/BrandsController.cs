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
    public class BrandsController : Controller
    {
        private IBrandReposirory brandRepository;

        public BrandsController(IBrandReposirory brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        // GET: Devices
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(brandRepository.GetBrands());
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

            return Ok(brandRepository.GetBrandByID(id));
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Brand brand)
        {
            if (brand.BrandId != null)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }
            if (ModelState.IsValid)
            {
                brandRepository.InsertBrand(brand);
                brandRepository.Save();
                return RedirectToAction(nameof(GetAll));
            }
            return RedirectToAction(nameof(GetAll));
        }



        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Brand brand)
        {
            if (id != brand.BrandId)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }

            if (ModelState.IsValid)
            {
                brandRepository.UpdateBrand(brand);
                brandRepository.Save();

                return RedirectToAction(nameof(GetAll));
            }
            return RedirectToAction(nameof(GetAll));
        }

        // POST: Devices/Delete/5
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Device with this id does not exist" });
            }

            brandRepository.DeleteBrand(id);
            brandRepository.Save();
            return RedirectToAction(nameof(GetAll));
        }
        protected override void Dispose(bool disposing)
        {
            brandRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
