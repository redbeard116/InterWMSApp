using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("producttypes", Schema = "public")]
    public class ProductType:BaseModel
    {
        public ProductType()
        {
            Products = new List<Product>();
        }

        [Column("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}