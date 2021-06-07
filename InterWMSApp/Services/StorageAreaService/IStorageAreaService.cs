using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.StorageAreaService
{
    interface IStorageAreaService
    {
        IEnumerable<StorageArea> GetStorageAreas();

        Task<StorageArea> GetStorageArea(int id);

        Task<StorageArea> AddStorageArea(StorageArea storageArea);
        Task<bool> DeleteStorageArea(int id);
        Task<StorageArea> EditStorageArea(StorageArea storageArea);
    }
}
