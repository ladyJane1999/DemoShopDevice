using PagedList;
using SiteShopCar.Model;
using System;
using System.Collections.Generic;
using System.Text;
namespace DemoShopDevice.Models
{
    public class PaginationDTO<T>
    {
        public IPagedList<T> ListEntity { get; set; }
        public int Count { get; set; }

        public PaginationDTO(IPagedList<T> listEntity, int count)
        {
            ListEntity = listEntity;
            Count=count;
        }

       
    }
}
