using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("contracts", Schema = "public")]
    public class Contract : BaseModel
    {
        
        [Column("counterpartyid"), Required]
        public int CounterpartyId { get; set; }

        public Counterparty Counterparty { get; set; }

        [Column("date"), Required]
        public long Date { get; set; }

        [Column("sum"), Required]
        public double Sum { get; set; }

        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("type"), Required]
        public OperationType Type { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }
    }


    public enum OperationType
    {
        Reception,
        Shipping
    }
}
