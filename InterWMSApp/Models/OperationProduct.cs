using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("operationproducts", Schema = "public")]
    public class OperationProduct : BaseModel
    {

        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("contractId"), Required]
        public int ContractId { get; set; }
        [JsonIgnore]
        public Contract Contract { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }

        [Column("sum"), Required]
        public double Sum { get; set; }
    }
}
