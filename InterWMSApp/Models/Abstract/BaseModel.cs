using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterWMSApp.Models.Abstract
{
    public abstract class BaseModel
    {
        [Key, Column("id")]
        public int Id { get; set; }

        public string ToJson(bool ignoreNulls = false)
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings
                {
                    NullValueHandling = ignoreNulls
                        ? NullValueHandling.Ignore
                        : NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
        }
    }
}
