using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductPriceService
{
    public interface IProductPriceService
    {
        IEnumerable<ProductPrice> GetProductPrices();

        Task<ProductPrice> GetProductPrice(int id);

        Task<ProductPrice> AddProductPrice(ProductPrice productPrice);
        Task<bool> DeleteProductPrice(int id);
        Task<ProductPrice> EditProductPrice(ProductPrice productPrice);
        Task<IEnumerable<ProductInfo>> GetLastPrices();
    }
}
