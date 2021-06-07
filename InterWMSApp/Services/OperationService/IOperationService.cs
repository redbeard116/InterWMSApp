using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.OperationService
{
    interface IOperationService
    {
        IEnumerable<Operation> GetOperations();

        Task<Operation> GetOperation(int id);

        Task<Operation> AddOperation(Operation operation);
        Task<bool> DeleteOperation(int id);
        Task<Operation> EditOperation(Operation operation);
    }
}
