using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
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

        [Column("number"), Required]
        public string Number { get; set; }
        [Column("middlename")]
        public string MiddleName { get; set; }

        [Column("role"), Required]
        public UserRole Role { get; set; }

        [JsonIgnore]
        public virtual Counterparty Counterparty { get; set; }
        [JsonIgnore]
        public virtual Auth Auth { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Logistics,
        Manager,
        Counterparty
    }
}