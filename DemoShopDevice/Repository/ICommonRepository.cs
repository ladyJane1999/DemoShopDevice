using System;
using System.Collections.Generic;
using DemoShopDevice.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PagedList;
using SiteShopCar.Model;

namespace ShopDevice.Repository
{
    public interface ICommonRepository<T> : IDisposable

    {
        PaginationDTO<T> GetEntity(int page,int limt);
        T GetEntityByID(int? entityId);
        void InsertEntity(T entity);
        void DeleteEntity(int entityID);
        void UpdateEntity(T entity);
        void Save();
    }
}
