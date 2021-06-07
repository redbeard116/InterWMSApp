using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductStorageService
{
    internal class ProductStorageService : IProductStorageService
    {
        #region Fields
        private readonly ILogger<ProductStorageService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public ProductStorageService(ILogger<ProductStorageService> logger,
                                     DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IProductStorageService
        public async Task<ProductStorage> AddProductStorage(ProductStorage productStorage)
        {
            try
            {
                _logger.LogInformation("Add product storage");
                await _dBContext.ProductStorages.AddAsync(productStorage);
                await _dBContext.SaveChangesAsync();
                return productStorage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddProductStorage)}");
                throw;
            }
        }

        public async Task<bool> DeleteProductStorage(int id)
        {
            try
            {
                _logger.LogInformation($"Delete product storage {id}");
                var product = await _dBContext.ProductStorages.FirstOrDefaultAsync(w => w.Id == id);
                _dBContext.ProductStorages.Remove(product);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteProductStorage)}");
                throw;
            }
        }

        public async Task<ProductStorage> EditProductStorage(ProductStorage productStorage)
        {
            try
            {
                _logger.LogInformation($"Edit product storage {productStorage.Id}");
                var result = _dBContext.ProductStorages.FirstOrDefault(w => w.Id == productStorage.Id);
                if (result != null)
                {
                    result.ProductId = productStorage.ProductId;
                    result.StorageAreaId = productStorage.StorageAreaId;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditProductStorage)}");
                throw;
            }
        }

        public async Task<ProductStorage> GetProductStorage(int id)
        {
            try
            {
                _logger.LogInformation($"Get product storage {id}");
                var product = await _dBContext.ProductStorages.FindAsync(id);
                if (product != null)
                {
                    return product;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProductStorage)}");
                throw;
            }
        }

        public IEnumerable<ProductStorage> GetProductStorages()
        {
            try
            {
                _logger.LogInformation("Get product storages");
                return _dBContext.ProductStorages;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProductStorages)}");
                throw;
            }
        }
        #endregion
    }
}
