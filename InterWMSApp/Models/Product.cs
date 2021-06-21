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
            ProductPrices = new List<ProductPrice>();
            OperationProducts = new List<OperationProduct>();
        }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("typeid"), Required]
        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Column("storageid"), Required]
        public int StorageAreaId { get; set; }
        public StorageArea StorageArea { get; set; }
        [JsonIgnore]
        public ICollection<ProductPrice> ProductPrices { get; set; }
        [JsonIgnore]
        public NumberProducts NumberProduct { get; set; }
        [JsonIgnore]
        public ICollection<OperationProduct> OperationProducts { get; set; }
    }
}
