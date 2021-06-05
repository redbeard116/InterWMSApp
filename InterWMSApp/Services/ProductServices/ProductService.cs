using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductServices
{
    internal class ProductService : IProductServices
    {
        #region Fields
        private readonly ILogger<ProductService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public ProductService(ILogger<ProductService> logger,
                              DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IProductServices
        public async Task<Product> GetProduct(int id)
        {
            try
            {
                _logger.LogInformation($"GetProduct {id}");
                var product = await _dBContext.Products.FindAsync(id);
                if (product != null)
                {
                    return product;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProduct)}");
                throw;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                _logger.LogInformation("GetProducts");
                return _dBContext.Products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProducts)}");
                throw;
            }
        }

        public async Task<int?> AddProduct(Product product)
        {
            try
            {
                _logger.LogInformation("AddProduct");
                await _dBContext.Products.AddAsync(product);
                await _dBContext.SaveChangesAsync();
                return product.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddProduct)}");
                throw;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                _logger.LogInformation($"DeleteProduct {id}");
                var product = _dBContext.Products.FirstOrDefault(w=>w.Id==id);
                _dBContext.Products.Remove(product);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteProduct)}");
                throw;
            }
        }

        public async Task<Product> EditProduct(Product product)
        {
            try
            {
                _logger.LogInformation($"EditProduct {product.Id}");
                var result = _dBContext.Products.FirstOrDefault(w=>w.Id == product.Id);
                if (result != null)
                {
                    result.Name = product.Name;
                    result.TypeId = product.TypeId;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditProduct)}");
                throw;
            }
        }
        #endregion
    }
}
