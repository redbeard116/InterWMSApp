using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.StorageAreaService
{
    interface IStorageAreaService
    {
        IEnumerable<StorageArea> GetStorageArea();

        Task<StorageArea> GetStorageArea(int id);

        Task<StorageArea> AddStorageArea(StorageArea counterparty);
        Task<bool> DeleteProductStorage(int id);
        Task<StorageArea> EditStorageArea(StorageArea counterparty);
    }
}
