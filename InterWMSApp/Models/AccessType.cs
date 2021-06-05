using InterWMSApp.Models.Abstract;
using Newtonsoft.Json;
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
        [JsonIgnore]
        public List<RightsGrid> RightsGrids { get; set; }
    }
}
