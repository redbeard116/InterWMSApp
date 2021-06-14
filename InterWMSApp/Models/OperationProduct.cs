using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("operationproducts", Schema = "public")]
    public class OperationProduct
    {

        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [JsonIgnore]
        [Column("count"), Required]
        public int ContractId { get; set; }
        [JsonIgnore]
        public Contract Contract { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }
    }
}
