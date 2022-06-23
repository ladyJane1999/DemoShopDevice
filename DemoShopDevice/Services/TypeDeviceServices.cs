using DemoShopDevice.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using ShopDevice.Repository;
using SiteShopCar.Data;
using SiteShopCar.Model;

namespace DeviceShop.Services
{
    public class TypeDeviceServices<T> : ICommonRepository<TypeDevice>, IDisposable
    {
        private readonly DbApplicationContext _context;

        public TypeDeviceServices(DbApplicationContext context)
        {
            _context = context;

        }

        public PaginationDTO<TypeDevice> GetEntity(int page, int limit)
        {
            var listTypeDevice = _context.TypeDevices.ToPagedList(page, limit);

            return new PaginationDTO<TypeDevice>(listTypeDevice, _context.TypeDevices.Count());
        }

        public TypeDevice GetEntityByID(int? id)
        {
            return _context.TypeDevices.Find(id);
        }

        public void InsertEntity(TypeDevice typeDevice)
        {
            _context.TypeDevices.Add(typeDevice);
        }

        public void DeleteEntity(int typeDevicetID)
        {
            TypeDevice typeDevice = _context.TypeDevices.Find(typeDevicetID);
            _context.TypeDevices.Remove(typeDevice);
        }

        public void UpdateEntity(TypeDevice typeDevice)
        {
            _context.Entry(typeDevice).State = EntityState.Modified;
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
