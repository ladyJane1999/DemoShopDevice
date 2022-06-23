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
    public class BrandsController : Controller
    {
        private ICommonRepository<Brand> brandRepository;

        public BrandsController(ICommonRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        // GET: Devices
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int limit)
        {
            return Ok(brandRepository.GetEntity(page, limit));
        }

        // GET: Devices/Details/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            return Ok(brandRepository.GetEntityByID(id));
        }

        // POST: Devices/Create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Brand brand)
        {
            if (ModelState.IsValid)
            {
                brandRepository.InsertEntity(brand);
                brandRepository.Save();
              
            }
            return Ok(new { message = "Brand created" });
        }



        // POST: Devices/Edit/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Brand brand)
        {

            if (ModelState.IsValid)
            {
                brandRepository.UpdateEntity(brand);
                brandRepository.Save();

            }
            return Ok(new { message = "Brand edited" });
        }

        // POST: Devices/Delete/5
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            brandRepository.DeleteEntity(id);
            brandRepository.Save();
            return Ok(new { message = "Brand delited" });
        }
        protected override void Dispose(bool disposing)
        {
            brandRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
