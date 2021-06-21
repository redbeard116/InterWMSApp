using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("storageareas", Schema = "public")]
    public class StorageArea : BaseModel
    {
        public StorageArea()
        {
            Products = new List<Product>();
        }

        [Column("location")]
        public string Location { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}