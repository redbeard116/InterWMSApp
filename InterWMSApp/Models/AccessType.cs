using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("accesstypes", Schema = "public")]
    public class AccessType : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
