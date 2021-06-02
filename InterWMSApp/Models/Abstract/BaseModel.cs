using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models.Abstract
{
    public abstract class BaseModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
