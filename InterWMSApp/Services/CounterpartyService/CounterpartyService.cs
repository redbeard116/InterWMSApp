using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.CounterpartyService
{
    internal class CounterpartyService : ICounterpartyService
    {
        #region Fields
        private readonly ILogger<CounterpartyService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public CounterpartyService(ILogger<CounterpartyService> logger,
                                   DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region ICounterpartyService
        public async Task<Counterparty> AddCounterparty(Counterparty counterparty)
        {
            try
            {
                _logger.LogInformation("Add new counterparty");
                await _dBContext.Counterparties.AddAsync(counterparty);
                await _dBContext.SaveChangesAsync();
                return counterparty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddCounterparty)}");
                throw;
            }
        }

        public async Task<bool> DeleteCounterparty(int id)
        {
            try
            {
                _logger.LogInformation($"Delete counterparty {id}");
                var result = await _dBContext.Counterparties.FirstOrDefaultAsync(w => w.Id == id);
                _dBContext.Counterparties.Remove(result);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteCounterparty)}");
                throw;
            }
        }

        public async Task<Counterparty> EditCounterparty(Counterparty counterparty)
        {
            try
            {
                _logger.LogInformation($"Edit ccounterparty {counterparty.Id}");
                var result = await _dBContext.Counterparties.FirstOrDefaultAsync(w => w.Id == counterparty.Id);
                if (result != null)
                {
                    result.UserId = counterparty.UserId;
                    result.INN = counterparty.INN;
                    result.Account = counterparty.Account;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditCounterparty)}");
                throw;
            }
        }

        public async Task<Counterparty> GetCounterparty(int id)
        {
            try
            {
                _logger.LogInformation($"Get counterparty {id}");
                var result = await _dBContext.Counterparties.FindAsync(id);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetCounterparty)}");
                throw;
            }
        }

        public IEnumerable<Counterparty> GetCounterpartyes()
        {
            try
            {
                _logger.LogInformation("Get ounterpartyes");
                return _dBContext.Counterparties;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetCounterpartyes)}");
                throw;
            }
        }
        #endregion
    }
}
