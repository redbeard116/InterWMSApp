using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("storageareas", Schema = "public")]
    public class StorageArea : BaseModel
    {
        [Column("location")]
        public string Location { get; set; }
    }
}
