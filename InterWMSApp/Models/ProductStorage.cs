using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("productstorage", Schema = "public")]
    public class ProductStorage : BaseModel
    {
        [Column("productid"), Required]
        public int ProductId { get; set; }

        [Column("storageareaid"), Required]
        public int StorageAreaId { get; set; }
    }
}
