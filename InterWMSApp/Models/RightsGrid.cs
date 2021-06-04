using InterWMSApp.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("rightsgrids", Schema = "public")]
    public class RightsGrid : BaseModel
    {
        [Column("accetTypeid")]
        public int AccessTypeId { get; set; }
        public AccessType AccessType { get; set; }

        [Column("userRole")]
        public UserRole UserRole { get; set; }
    }
}
