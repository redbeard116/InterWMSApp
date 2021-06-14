using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace InterWMSApp.Models
{
    [Table("contracts", Schema = "public")]
    public class Contract : BaseModel
    {
        public Contract()
        {
            OperationProducts = new List<OperationProduct>();
        }

        [Column("counterpartyid"), Required]
        public int CounterpartyId { get; set; }

        public Counterparty Counterparty { get; set; }

        [Column("date"), Required]
        public long Date { get; set; }

        [Column("sum"), Required]
        public double Sum { get; set; }
        [Column("products"), Required]
        public ICollection<OperationProduct> OperationProducts { get; set; }

        [Column("type"), Required]
        public OperationType Type { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }

        public ContractApiM GetContractApiM()
        {
            return new ContractApiM
            {
                Id = Id,
                Count = Count,
                Counterparty = Counterparty,
                Date = Date,
                Products = OperationProducts,
                Sum = Sum,
                Type = Type
            };
    }
}


public enum OperationType
{
    Reception,
    Shipping
}
}
