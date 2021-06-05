using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ProductServices
{
    public interface IProductServices
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProduct(int id);
        Task<int?> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> EditProduct(Product product);
    }
}
