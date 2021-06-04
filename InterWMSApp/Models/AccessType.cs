using InterWMSApp.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models
{
    [Table("accesstypes", Schema = "public")]
    public class AccessType : BaseModel
    {
        public AccessType()
        {
            RightsGrids = new List<RightsGrid>();
        }

        [Column("name")]
        public string Name { get; set; }
        public List<RightsGrid> RightsGrids { get; set; }
    }
}
