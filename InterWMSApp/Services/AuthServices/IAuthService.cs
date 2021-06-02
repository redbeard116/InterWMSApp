using InterWMSApp.Models;
using System.Threading.Tasks;

namespace InterWMSApp.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> GetUser(UserAuth user);
    }
}
