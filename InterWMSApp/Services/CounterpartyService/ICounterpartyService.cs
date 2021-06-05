using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.CounterpartyService
{
    interface ICounterpartyService
    {
        IEnumerable<Counterparty> GetCounterpartyes();

        Task<Counterparty> GetCounterparty(int id);

        Task<Counterparty> AddCounterparty(Counterparty counterparty);
        Task<bool> DeleteCounterparty(int id);
        Task<Counterparty> EditCounterparty(Counterparty counterparty);
    }
}
