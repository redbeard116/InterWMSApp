using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.DictionaryService
{
    public interface IDictionaryService
    {
        IEnumerable<AccessType> GetAccessTypes();
        Task<AccessType> AddAccessType(AccessType accessType);
        Task<bool> DeleteAccessType(int id);

        IEnumerable<ProductType> GetProductTypes();
        Task<ProductType> AddProductTypes(ProductType productType);
        Task<bool> DeleteProductTypes(int id);

        IEnumerable<UserRole> GetUserRoles();
        IEnumerable<OperationType> GetOperationTypes();

        IEnumerable<RightsGrid> GetRightsGrids();
    }
}