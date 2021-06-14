using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ContractService
{
    public interface IContractService
    {
        IEnumerable<ContractApiM> GetContracts();

        Task<ContractApiM> GetContract(int id);

        Task<ContractApiM> AddContract(ContractApiM contract);
        Task<bool> DeleteContract(int id);
        Task<ContractApiM> EditContract(ContractApiM contract);
    }
}
