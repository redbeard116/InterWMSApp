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
            ProductStorages = new List<ProductStorage>();
        }

        [Column("location")]
        public string Location { get; set; }
        [JsonIgnore]
        public List<ProductStorage> ProductStorages { get; set; }
    }
}