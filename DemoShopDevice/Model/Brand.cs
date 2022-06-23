using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteShopCar.Model
{
    [Table("brand")]
    public class Brand
    {
        [Key]
        [Column("id")]
        public int BrandId { get; set; }
        [Column("name")]
        public string Name { get; set; }
      
    }
}
