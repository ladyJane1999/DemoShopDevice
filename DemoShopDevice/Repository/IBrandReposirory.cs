using SiteShopCar.Model;

namespace DeviceShop.Repository
{
    public interface IBrandReposirory : IDisposable
    {
        IEnumerable<Brand> GetBrands();
        Brand GetBrandByID(int? brandId);
        void InsertBrand(Brand brand);
        void DeleteBrand(int brandID);
        void UpdateBrand(Brand brand);
        void Save();
    }
}
