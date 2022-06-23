using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteShopCar.Model
{
    [Table("type_device")]
    public class TypeDevice
    {
        [Key]
        [Column("id")]
        public int TypeDeviceId { get; set; }
        [Column("name")]
        public string Name { get; set; }

    }
}
