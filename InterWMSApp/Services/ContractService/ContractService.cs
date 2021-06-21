using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using InterWMSApp.Services.ProductPriceService;
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
        private readonly IProductPriceService _productPriceService;
        #endregion

        #region Constructor
        public ContractService(ILogger<ContractService> logger,
                               DBContext dBContext,
                               IProductPriceService productPriceService)
        {
            _logger = logger;
            _dBContext = dBContext;
            _productPriceService = productPriceService;
        }
        #endregion

        #region IContractService
        public async Task<ContractApiM> AddContract(ContractApiM contract)
        {
            try
            {
                _logger.LogInformation("Add new contract");
                var contractDb = contract.GetContract();
                contractDb.OperationProducts.ToList().ForEach(w => w.Product = null);
                await _dBContext.Contracts.AddAsync(contractDb);
                await _dBContext.SaveChangesAsync();
                if (contractDb.Type == OperationType.Reception)
                {
                    var prices = contractDb.OperationProducts.Select(w => new ProductPrice
                    {
                        Date = contractDb.Date,
                        PriceType = PriceType.Purchase,
                        ProductId = w.ProductId,
                        Product = w.Product,
                        Cost = (double)w.Sum / w.Count
                    });

                    foreach (var price in prices)
                    {
                        await _productPriceService.AddProductPrice(price);
                    }

                }
                contract.Id = contractDb.Id;
                await SyncProductCounts(contractDb);
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
                await SyncProductCountsDelete(result);
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

        public async Task<IEnumerable<ContractApiM>> GetContracts()
        {
            try
            {
                _logger.LogInformation("Get contracts");
                var result = await _dBContext.Contracts.Include(w => w.Counterparty)
                                           .Include(w => w.Counterparty.User)
                                           .Include(w => w.OperationProducts)
                                           .ThenInclude(w => w.Product).ToListAsync();

                return result.Select(w => w.GetContractApiM());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetContracts)}");
                throw;
            }
        }
        #endregion

        #region Private methods
        private async Task SyncProductCounts(Contract contract)
        {
            foreach (var operationProd in contract.OperationProducts)
            {
                var numberProduct = await _dBContext.NumberProducts.FirstOrDefaultAsync(w => w.ProductId == operationProd.ProductId);

                if (numberProduct == null)
                {
                    continue;
                }

                if (contract.Type == OperationType.Reception)
                {
                    numberProduct.Count += operationProd.Count;
                }
                if (contract.Type == OperationType.Shipping)
                {
                    numberProduct.Count -= operationProd.Count;
                }

                await _dBContext.SaveChangesAsync();
            }
        }

        private async Task SyncProductCountsDelete(Contract contract)
        {
            foreach (var operationProd in contract.OperationProducts)
            {
                var numberProduct = await _dBContext.NumberProducts.FirstOrDefaultAsync(w => w.ProductId == operationProd.ProductId);

                if (numberProduct == null)
                {
                    continue;
                }

                if (contract.Type == OperationType.Reception)
                {
                    numberProduct.Count -= operationProd.Count;
                }
                if (contract.Type == OperationType.Shipping)
                {
                    numberProduct.Count += operationProd.Count;
                }

                await _dBContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
