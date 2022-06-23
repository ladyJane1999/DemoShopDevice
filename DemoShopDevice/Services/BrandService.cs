using DeviceShop.Repository;
using Microsoft.EntityFrameworkCore;
using SiteShopCar.Data;
using SiteShopCar.Model;

namespace DeviceShop.Services
{
    public class BrandService: IBrandReposirory, IDisposable
    {
        private readonly DbApplicationContext _context;

        public BrandService(DbApplicationContext context)
        {
            _context = context;

        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public Brand GetBrandByID(int? id)
        {
            return _context.Brands.Find(id);
        }

        public void InsertBrand(Brand brand)
        {
            _context.Brands.Add(brand);
        }

        public void DeleteBrand(int brandID)
        {
            Brand brand = _context.Brands.Find(brandID);
            _context.Brands.Remove(brand);
        }

        public void UpdateBrand(Brand brand)
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
