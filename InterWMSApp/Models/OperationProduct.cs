using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("operationproducts", Schema = "public")]
    public class OperationProduct : BaseModel
    {
        public OperationProduct()
        {
            Operations = new List<Operation>();
        }

        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }

        [JsonIgnore]
        public List<Operation> Operations { get; set; }
    }
}
