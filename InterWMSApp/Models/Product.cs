using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("products", Schema = "public")]
    public class Product : BaseModel
    {
        public Product()
        {
            ProductStorages = new List<ProductStorage>();
            Operations = new List<Operation>();
        }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("typeid"), Required]
        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }
        [JsonIgnore]
        public List<ProductStorage> ProductStorages { get; set; }
        [JsonIgnore]
        public List<Operation> Operations { get; set; }
    }
}
