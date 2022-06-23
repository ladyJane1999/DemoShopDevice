using SiteShopCar.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Model
{
    [Table("backet_device")]
    public class Backet_device
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("device_id")]
        public Device Device { get; set; }

        [ForeignKey("backet_id")]
        public Backet Backet { get; set; }
    }
}
