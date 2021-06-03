using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("producttypes", Schema = "public")]
    public class ProductType:BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
    }
}