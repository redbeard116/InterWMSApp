using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("operations", Schema = "public")]
    public class Operation: BaseModel
    {
        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("type"), Required]
        public OperationType Type { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }

        //[Column("products")]
        //public List<int> OperationProductsIds { get; set; }
        //public List<OperationProduct> OperationProducts { get; set; }
    }

    public enum OperationType
    {
        Reception,
        Shipping
    }
}
