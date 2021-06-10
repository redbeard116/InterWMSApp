using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProduct(int id);
        Task<int?> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> EditProduct(Product product);
    }
}
