using System.Collections.Generic;
using System.Linq;

namespace InterWMSApp.Models
{
    public class ProductsReport
    {
        public string ReportName { get; set; }

        public IEnumerable<ReportProduct> ReportProducts { get; set; }
    }

    public class ReportProduct
    {
        public string Name { get; set; }
        public IEnumerable<ReportProductInfo> Infos { get; set; }
        public int Count => Infos.Sum(w => w.Count);
    }

    public class ReportProductInfo
    {
        public int Count { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
    }
}
