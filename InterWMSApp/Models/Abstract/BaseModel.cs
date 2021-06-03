using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models.Abstract
{
    public abstract class BaseModel
    {
        [Key, Column("id")]
        public int Id { get; set; }
    }
}
