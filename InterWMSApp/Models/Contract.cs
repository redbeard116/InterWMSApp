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

        [Column("operationid"), Required]
        public int OperationId { get; set; }

        public Operation Operation { get; set; }

        [Column("date"), Required]
        public long Date { get; set; }
    }
}
