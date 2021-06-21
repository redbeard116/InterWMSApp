using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("prices", Schema = "public")]
    public class ProductPrice : BaseModel
    {
        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("cost")]
        public double Cost { get; set; }
        [Column("date")]
        public long Date { get; set; }
        [Column("type")]
        public PriceType PriceType { get; set; }
    }

    public enum PriceType
    {
        Purchase,
        Sale
    }
}
