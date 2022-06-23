using SiteShopCar.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Model
{
    [Table("device_info")]
    public class Device_info
    {
        
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("device_id")]
        public Device Device { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
