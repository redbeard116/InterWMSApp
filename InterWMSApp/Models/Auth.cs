using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("auths", Schema = "public")]
    public class Auth : BaseModel
    {
        [Column("userid"), Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Column("login"), Required]
        public string Login { get; set; }

        [Column("password"), Required]
        public string Password { get; set; }
    }
}
