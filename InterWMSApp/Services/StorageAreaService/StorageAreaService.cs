using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.StorageAreaService
{
    internal class StorageAreaService : IStorageAreaService
    {
        #region Fields
        private readonly ILogger<StorageAreaService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public StorageAreaService(ILogger<StorageAreaService> logger,
                                  DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IStorageAreaService
        public async Task<StorageArea> AddStorageArea(StorageArea storageArea)
        {
            try
            {
                _logger.LogInformation("Add storage area");
                await _dBContext.StorageAreas.AddAsync(storageArea);
                await _dBContext.SaveChangesAsync();
                return storageArea;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddStorageArea)}");
                throw;
            }
        }

        public async Task<bool> DeleteStorageArea(int id)
        {
            try
            {
                _logger.LogInformation($"Delete storage area {id}");
                var product = await _dBContext.StorageAreas.FirstOrDefaultAsync(w => w.Id == id);
                _dBContext.StorageAreas.Remove(product);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteStorageArea)}");
                throw;
            }
        }

        public async Task<StorageArea> EditStorageArea(StorageArea storageArea)
        {
            try
            {
                _logger.LogInformation($"Edit product storage {storageArea.Id}");
                var result = _dBContext.StorageAreas.FirstOrDefault(w => w.Id == storageArea.Id);
                if (result != null)
                {
                    result.Location = storageArea.Location;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditStorageArea)}");
                throw;
            }
        }

        public IEnumerable<StorageArea> GetStorageAreas()
        {
            try
            {
                _logger.LogInformation("Get storage area");
                return _dBContext.StorageAreas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetStorageAreas)}");
                throw;
            }
        }

        public async Task<StorageArea> GetStorageArea(int id)
        {
            try
            {
                _logger.LogInformation($"Get storage area {id}");
                var product = await _dBContext.StorageAreas.FindAsync(id);
                if (product != null)
                {
                    return product;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetStorageArea)}");
                throw;
            }
        }
        #endregion
    }
}
