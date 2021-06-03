using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("users", Schema = "public")]
    public class User : BaseModel
    {
        [Column("firstname"), Required]
        public string FirstName { get; set; }

        [Column("secondname"), Required]
        public string SecondName { get; set; }

        [Column("role"), Required]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Сounterparty,
        Manager
    }
}
