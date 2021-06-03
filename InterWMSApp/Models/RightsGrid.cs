using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("rightsgrids", Schema = "public")]
    public class RightsGrid
    {
        [Column("accetTypeid")]
        public int AccessTypeId { get; set; }

        [Column("userRole")]
        public UserRole UserRole { get; set; }
    }
}
