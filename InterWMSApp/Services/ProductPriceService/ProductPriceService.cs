﻿using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductPriceService
{
    internal class ProductPriceService : IProductPriceService
    {
        #region Fields
        private readonly ILogger<ProductPriceService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public ProductPriceService(ILogger<ProductPriceService> logger,
                                   DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IProductPriceService
        public async Task<ProductPrice> AddProductPrice(ProductPrice productPrice)
        {
            try
            {
                _logger.LogInformation("Add product price");
                await _dBContext.ProductPrices.AddAsync(productPrice);
                await _dBContext.SaveChangesAsync();
                return productPrice;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddProductPrice)}");
                throw;
            }
        }

        public async Task<bool> DeleteProductPrice(int id)
        {
            try
            {
                _logger.LogInformation($"Delete product price {id}");
                var result = await _dBContext.ProductPrices.FirstOrDefaultAsync(w => w.Id == id);
                _dBContext.ProductPrices.Remove(result);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteProductPrice)}");
                throw;
            }
        }

        public async Task<ProductPrice> EditProductPrice(ProductPrice productPrice)
        {
            try
            {
                _logger.LogInformation($"Edit product price {productPrice.Id}");
                var result = await _dBContext.ProductPrices.FirstOrDefaultAsync(w => w.Id == productPrice.Id);
                if (result != null)
                {
                    result.ProductId = productPrice.ProductId;
                    result.Cost = productPrice.Cost;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditProductPrice)}");
                throw;
            }
        }

        public async Task<IEnumerable<ProductInfo>> GetLastPrices()
        {
            try
            {
                _logger.LogInformation("Get last product prices");

                var groupPrices = (await _dBContext.ProductPrices.Include(w => w.Product).ToListAsync()).GroupBy(w => w.ProductId);


                var prices = groupPrices.Select(w => w.LastOrDefault(p => p.PriceType == PriceType.Sale)).Where(w => w != null);

                return from p in prices
                       join c in _dBContext.NumberProducts on p.ProductId equals c.ProductId
                       select new ProductInfo
                       {
                           ProductId = p.ProductId,
                           Cost = p.Cost,
                           Date = p.Date,
                           Count = c.Count
                       };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetLastPrices)}");
                throw;
            }
        }

        public async Task<ProductPrice> GetProductPrice(int id)
        {
            try
            {
                _logger.LogInformation($"Get product price {id}");
                var result = await _dBContext.ProductPrices.FindAsync(id);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProductPrice)}");
                throw;
            }
        }

        public IEnumerable<ProductPrice> GetProductPrices()
        {
            try
            {
                _logger.LogInformation("Get product prices");
                return _dBContext.ProductPrices.Include(w => w.Product).Where(w => w.PriceType == PriceType.Sale);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetProductPrices)}");
                throw;
            }
        }
        #endregion
    }
}
