using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.OperationService
{
    internal class OperationService : IOperationService
    {
        #region Fields
        private readonly ILogger<OperationService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public OperationService(ILogger<OperationService> logger,
                                DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IOperationService
        public async Task<Operation> AddOperation(Operation operation)
        {
            try
            {
                _logger.LogInformation("Add new operation");
                await _dBContext.Operations.AddAsync(operation);
                await _dBContext.SaveChangesAsync();
                return operation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddOperation)}");
                throw;
            }
        }

        public async Task<bool> DeleteOperation(int id)
        {
            try
            {
                _logger.LogInformation($"Delete operation {id}");
                var result = await _dBContext.Operations.FirstOrDefaultAsync(w => w.Id == id);
                _dBContext.Operations.Remove(result);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteOperation)}");
                throw;
            }
        }

        public async Task<Operation> EditOperation(Operation operation)
        {
            try
            {
                _logger.LogInformation($"Edit operation {operation.Id}");
                var result = _dBContext.Operations.FirstOrDefault(w => w.Id == operation.Id);
                if (result != null)
                {
                    result.Count = operation.Count;
                    result.ProductId = operation.ProductId;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditOperation)}");
                throw;
            }
        }

        public async Task<Operation> GetOperation(int id)
        {
            try
            {
                _logger.LogInformation($"Get operation {id}");
                var result = await _dBContext.Operations.FindAsync(id);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetOperation)}");
                throw;
            }
        }

        public IEnumerable<Operation> GetOperations()
        {
            try
            {
                _logger.LogInformation("Get operation");
                return _dBContext.Operations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetOperations)}");
                throw;
            }
        }
        #endregion
    }
}
