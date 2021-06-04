using InterWMSApp.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("users", Schema = "public")]
    public class User : BaseModel
    {
        public User()
        {
            Counterparties = new List<Counterparty>();
            Auths = new List<Auth>();
        }

        [Column("firstname"), Required]
        public string FirstName { get; set; }

        [Column("secondname"), Required]
        public string SecondName { get; set; }

        [Column("role"), Required]
        public UserRole Role { get; set; }

        public List<Counterparty> Counterparties { get; set; }
        public List<Auth> Auths { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Сounterparty,
        Manager
    }
}
