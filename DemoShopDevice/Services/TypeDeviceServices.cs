using DeviceShop.Repository;
using Microsoft.EntityFrameworkCore;
using SiteShopCar.Data;
using SiteShopCar.Model;

namespace DeviceShop.Services
{
    public class TypeDeviceServices : ITypeDevicesRepository, IDisposable
    {
        private readonly DbApplicationContext _context;

        public TypeDeviceServices(DbApplicationContext context)
        {
            _context = context;

        }

        public IEnumerable<TypeDevice> GetTypeDevices()
        {
            return _context.TypeDevices.ToList();
        }

        public Device GetTypeDeviceByID(int? id)
        {
            return _context.Devices.Find(id);
        }

        public void InsertTypeDevice(TypeDevice typeDevice)
        {
            _context.TypeDevices.Add(typeDevice);
        }

        public void DeleteTypeDevice(int typeDevicetID)
        {
            TypeDevice typeDevice = _context.TypeDevices.Find(typeDevicetID);
            _context.TypeDevices.Remove(typeDevice);
        }

        public void UpdateTypeDevice(TypeDevice typeDevice)
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

