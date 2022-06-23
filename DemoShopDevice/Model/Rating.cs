using SiteShopCar.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Model
{
    [Table("rating")]
    public class Rating
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("rate")]
        public int Rate { get; set; }

        [ForeignKey("device_id")]
        public Device Device { get; set; }

        [ForeignKey("user_id")]
        public Users User { get; set; }
    }
}
