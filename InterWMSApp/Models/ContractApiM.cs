using InterWMSApp.Models.Abstract;
using System.Collections.Generic;

namespace InterWMSApp.Models
{
    public class ContractApiM : BaseModel
    {
        public Counterparty Counterparty { get; set; }

        public long Date { get; set; }

        public double Sum { get; set; }
        public ICollection<OperationProduct> Products { get; set; }

        public OperationType Type { get; set; }

        public Contract GetContract()
        {
            return new Contract
            {
                CounterpartyId = Counterparty.Id,
                Date = Date,
                Sum = Sum,
                Type = Type,
                OperationProducts = Products
            };
        }
    }
}
