using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Model
{
    [Table("users")]
    public class Users
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }

    }
}
