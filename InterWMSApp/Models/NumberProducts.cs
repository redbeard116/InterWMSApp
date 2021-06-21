using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("numberproducts", Schema = "public")]
    public class NumberProducts : BaseModel
    {

        [Column("productid"), Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("count"), Required]
        public int Count { get; set; }
    }
}
