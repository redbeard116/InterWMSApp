using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("products", Schema = "public")]
    public class Product : BaseModel
    {
        [Column("name"), Required]
        public string Name { get; set; }

        [Column("typeid"), Required]
        public int TypeId { get; set; }
    }
}
