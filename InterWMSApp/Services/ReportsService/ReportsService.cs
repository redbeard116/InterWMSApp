using InterWMSApp.Extensions;
using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InterWMSApp.Services.ReportsService
{
    public class ReportsService : IReportsService
    {
        #region Fields
        private readonly ILogger<ReportsService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public ReportsService(ILogger<ReportsService> logger,
                              DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IReportsService
        public async Task<ProductsReport> GetProductsReport(OperationType operationType, long startTime, long endTime)
        {
            _logger.LogDebug("Create sales products report");

            var report = new ProductsReport();

            var text = operationType == OperationType.Reception ? "принятого" : "проданного";
            report.ReportName = $"Количество {text} товара за {startTime.GetNormalTime().ToString("dd.MM.yyyy HH:mm")} - {endTime.GetNormalTime().ToString("dd.MM.yyyy HH:mm")}";

            var reportProducts = new List<ReportProduct>();

            var operationProducts = _dBContext.OperationProducts.Include(w => w.Contract).Include(w => w.Product);

            var products = await operationProducts.Where(w => w.Contract.Type == operationType && w.Contract.Date > startTime && w.Contract.Date < endTime).ToListAsync();

            var groups = products.GroupBy(w => w.ProductId);

            foreach (var group in groups)
            {
                var reportProduct = new ReportProduct();
                reportProduct.Name = group.FirstOrDefault().Product.Name;

                var grouppingProductInfo = group.GroupBy(w => w.Contract.Date.GetNormalTime().ToString("dd.MM.yyyy"));

                reportProduct.Infos = grouppingProductInfo.Select(w => new ReportProductInfo { Date = w.Key, Count = w.Sum(c => c.Count), Price = w.Sum(p => p.Sum / p.Count) / w.Count() });

                reportProducts.Add(reportProduct);
            }

            report.ReportProducts = reportProducts;
            return report;
        }
        #endregion
    }
}
