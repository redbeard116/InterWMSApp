using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ContractService
{
    internal class ContractService : IContractService
    {
        #region Fields
        private readonly ILogger<ContractService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public ContractService(ILogger<ContractService> logger,
                               DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IContractService
        public async Task<ContractApiM> AddContract(ContractApiM contract)
        {
            try
            {
                _logger.LogInformation("Add new contract");
                var contractDb = contract.GetContract();
                await _dBContext.Contracts.AddAsync(contractDb);
                await _dBContext.SaveChangesAsync();
                contract.Id = contractDb.Id;
                return contract;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddContract)}");
                throw;
            }
        }

        public async Task<bool> DeleteContract(int id)
        {
            try
            {
                _logger.LogInformation($"Delete contract {id}");
                var result = await _dBContext.Contracts.FirstOrDefaultAsync(w => w.Id == id);
                _dBContext.Contracts.Remove(result);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteContract)}");
                throw;
            }
        }

        public async Task<ContractApiM> EditContract(ContractApiM contract)
        {
            try
            {
                _logger.LogInformation($"Edit contract {contract.Id}");
                var result = await _dBContext.Contracts.FirstOrDefaultAsync(w => w.Id == contract.Id);
                if (result != null)
                {
                    result.CounterpartyId = contract.Counterparty.Id;
                    result.Date = contract.Date;
                    result.Sum = contract.Sum;
                    await _dBContext.SaveChangesAsync();
                    return contract;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditContract)}");
                throw;
            }
        }

        public async Task<ContractApiM> GetContract(int id)
        {
            try
            {
                _logger.LogInformation($"Get contract {id}");
                var result = await _dBContext.Contracts.FindAsync(id);
                if (result != null)
                {
                    return result.GetContractApiM();
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetContract)}");
                throw;
            }
        }

        public IEnumerable<ContractApiM> GetContracts()
        {
            try
            {
                _logger.LogInformation("Get contracts");
                return _dBContext.Contracts.Select(w => w.GetContractApiM());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetContracts)}");
                throw;
            }
        }
        #endregion
    }
}
