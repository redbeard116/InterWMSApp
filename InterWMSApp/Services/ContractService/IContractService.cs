using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ContractService
{
    public interface IContractService
    {
        IEnumerable<Contract> GetContracts();

        Task<Contract> GetContract(int id);

        Task<Contract> AddContract(Contract contract);
        Task<bool> DeleteContract(int id);
        Task<Contract> EditContract(Contract contract);
    }
}
