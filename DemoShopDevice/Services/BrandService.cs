using DemoShopDevice.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using ShopDevice.Repository;
using SiteShopCar.Data;
using SiteShopCar.Model;

namespace DeviceShop.Services
{
    public class BrandService<T>: ICommonRepository<Brand>, IDisposable
    {
        private readonly DbApplicationContext _context;

        public BrandService(DbApplicationContext context)
        {
            _context = context;

        }

        public PaginationDTO<Brand>  GetEntity(int page, int limit)
        {
            var listBrand = _context.Brands.ToPagedList(page, limit);

            return new PaginationDTO<Brand>(listBrand, _context.Brands.Count());
        }

        public Brand GetEntityByID(int? id)
        {
            return _context.Brands.Find(id);
        }

        public void InsertEntity(Brand brand)
        {
            _context.Brands.Add(brand);
        }

        public void DeleteEntity(int brandID)
        {
            Brand brand = _context.Brands.Find(brandID);
            _context.Brands.Remove(brand);
        }

        public void UpdateEntity(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
