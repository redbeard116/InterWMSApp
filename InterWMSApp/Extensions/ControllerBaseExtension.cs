using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InterWMSApp.Extensions
{
    public static class ControllerBaseExtension
    {
        public static async Task<string> GetStringFromBody(this ControllerBase controller)
        {
            using (StreamReader reader = new StreamReader(controller.Request.Body, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
