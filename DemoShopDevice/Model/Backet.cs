using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Model
{
    [Table("backet")]
    public class Backet
    {
        [ForeignKey("user_id")]
        [Key]
        public int Id { get; set; }
        [Column("user_id")]
        public Users User { get; set; }

    }
}
