using InterWMSApp.Models;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ReportsService
{
    public interface IReportsService
    {
        Task<ProductsReport> GetProductsReport(OperationType operationType, long startTime, long endTime);
    }
}
