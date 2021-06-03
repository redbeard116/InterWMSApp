using InterWMSApp.Models;
using System.Threading.Tasks;

namespace InterWMSApp.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> GetUserAuth(UserAuth user);
    }
}
