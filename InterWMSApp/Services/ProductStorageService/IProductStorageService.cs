using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductStorageService
{
    interface IProductStorageService
    {
        IEnumerable<ProductStorage> GetProductStorages();

        Task<ProductStorage> GetProductStorage(int id);

        Task<ProductStorage> AddProductStorage(ProductStorage counterparty);
        Task<bool> DeleteProductStorage(int id);
        Task<ProductStorage> EditProductStorage(ProductStorage counterparty);
    }
}
