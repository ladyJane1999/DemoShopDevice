using SiteShopCar.Model;

namespace DeviceShop.Repository
{
    public interface ITypeDevicesRepository : IDisposable
    {
        IEnumerable<TypeDevice> GetTypeDevices();
        Device GetTypeDeviceByID(int? typeDeviceId);
        void InsertTypeDevice(TypeDevice typeDevice);
        void DeleteTypeDevice(int typeDeviceID);
        void UpdateTypeDevice(TypeDevice typeDevice);
        void Save();
    }
}
