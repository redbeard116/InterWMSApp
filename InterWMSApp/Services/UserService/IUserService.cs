using InterWMSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterWMSApp.Services.UserService
{
    public interface IUserService
    {
        Task<int?> AddUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> EditUser(User user);
        Task<User> GetUser(int id);
        IEnumerable<User> GetUsers();
    }
}
