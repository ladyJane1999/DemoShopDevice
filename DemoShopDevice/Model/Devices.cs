using ProjectDemo.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteShopCar.Model
{
    [Table("device")]
    public class Device
    {
        [Key]
        [Column("id")]
        public int DeviceId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("img")]
        public string Img { get; set; }

        [Column("rating")]
        public Rating rating { get; set; }

        [ForeignKey("brand_id")]
        public Brand Brand { get; set; }

        [ForeignKey("device_id")]
        public TypeDevice DeviceType { get; set; }
        

    }
}
