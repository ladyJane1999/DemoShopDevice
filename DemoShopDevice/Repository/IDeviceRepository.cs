using System;
using System.Collections.Generic;
using DemoShopDevice.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PagedList;
using SiteShopCar.Model;

namespace ShopDevice.Repository
{
    public interface IDeviceRepository<T> : IDisposable

    {
        PaginationDTO<T> GetDevices(int page,int limt);
        Device GetDeviceByID(int? deviceId);
        void InsertDevice(T device);
        void DeleteDevice(int devicetID);
        void UpdateDevice(T device);
        void Save();
    }
}
