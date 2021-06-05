using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace InterWMSApp.Services.DictionaryService
{
    public class DictionaryService : IDictionaryService
    {
        #region Fields
        private readonly ILogger<DictionaryService> _logger;
        private readonly DBContext _dBContext;
        #endregion


        #region Constructor
        public DictionaryService(ILogger<DictionaryService> logger,
                                 DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IDictionaryService
        public IEnumerable<AccessType> GetAccessTypes()
        {
            try
            {
                _logger.LogDebug("Get all access types");
                return _dBContext.AccessTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetAccessTypes)}");
                throw;
            }
        }
        public async Task<AccessType> AddAccessType(AccessType accessType)
        {
            try
            {
                _logger.LogInformation("Add access type");
                await _dBContext.AccessTypes.AddAsync(accessType);
                await _dBContext.SaveChangesAsync();
                return accessType;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddAccessType)}");
                throw;
            }
        }
        public async Task<bool> DeleteAccessType(int id)
        {
            try
            {
                _logger.LogInformation($"Delete access type {id}");
                var accessType = _dBContext.AccessTypes.FirstOrDefault(w => w.Id == id);

                if (accessType == null)
                {
                    return false;
                }

                _dBContext.AccessTypes.Remove(accessType);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddAccessType)}");
                throw;
            }
        }


        public IEnumerable<OperationType> GetOperationTypes()
        {
            try
            {
                _logger.LogDebug("Get all operation types");
                return Enum.GetValues(typeof(OperationType)).Cast<OperationType>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetOperationTypes)}");
                throw;
            }
        }
        public async Task<ProductType> AddProductTypes(ProductType productType)
        {
            try
            {
                _logger.LogInformation("Add product type");
                await _dBContext.ProductTypes.AddAsync(productType);
                await _dBContext.SaveChangesAsync();
                return productType;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddProductTypes)}");
                throw;
            }
        }

        public async Task<bool> DeleteProductTypes(int id)
        {
            try
            {
                _logger.LogInformation($"Delete product type {id}");
                var productType = _dBContext.ProductTypes.FirstOrDefault(w => w.Id == id);

                if (productType == null)
                {
                    return false;
                }

                _dBContext.ProductTypes.Remove(productType);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteProductTypes)}");
                throw;
            }
        }


        public IEnumerable<ProductType> GetProductTypes()
        {
            try
            {
                _logger.LogDebug("Get all product types");
                return _dBContext.ProductTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProductTypes)}");
                throw;
            }
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            try
            {
                _logger.LogDebug("Get all user roles");
                return Enum.GetValues(typeof(UserRole)).Cast<UserRole>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetUserRoles)}");
                throw;
            }
        }

        public IEnumerable<RightsGrid> GetRightsGrids()
        {
            try
            {
                _logger.LogDebug("Get all rights grids");
                return _dBContext.RightsGrids;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetRightsGrids)}");
                throw;
            }
        }
        #endregion
    }
}
