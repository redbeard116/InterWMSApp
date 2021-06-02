using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("users", Schema = "public")]
    public class User : BaseModel
    {
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("secondname")]
        public string SecondName { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("role")]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User,
        Manager
    }
}
