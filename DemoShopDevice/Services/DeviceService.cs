using Microsoft.EntityFrameworkCore;
using ShopDevice.Repository;
using SiteShopCar.Data;
using SiteShopCar.Model;
using PagedList;
using DemoShopDevice.Models;

namespace ShopDevice.Services
{
    public class DeviceService<T> : IDeviceRepository<Device>, IDisposable
    {
        private readonly DbApplicationContext _context;

        public DeviceService(DbApplicationContext context)
        {
            _context = context;
          
        }
        public PaginationDTO<Device> GetDevices(int page, int limit)
        {
            var listDevice = _context.Devices.ToPagedList(page, limit);

            return new PaginationDTO<Device>(listDevice, _context.Devices.Count());
        }

        public Device GetDeviceByID(int? id)
        {
            return _context.Devices.Find(id);
        }

        public void InsertDevice(Device device)
        {
            _context.Devices.Add(device);
        }

        public void DeleteDevice(int studentID)
        {
            Device student = _context.Devices.Find(studentID);
            _context.Devices.Remove(student);
        }

        public void UpdateDevice(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
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

