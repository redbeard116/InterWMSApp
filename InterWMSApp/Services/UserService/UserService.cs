using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterWMSApp.Services.UserService
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly ILogger<UserService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public UserService(ILogger<UserService> logger,
                          DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IUserService
        public async Task<int?> AddUser(User user)
        {
            try
            {
                _logger.LogInformation("AddUser");
                await _dBContext.Users.AddAsync(user);
                await _dBContext.SaveChangesAsync();
                return user.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddUser error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
                return null;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation($"DeleteUser {id}");
                var user = await _dBContext.Users.FirstOrDefaultAsync(w => w.Id == id);

                var auth = await _dBContext.Auths.FirstOrDefaultAsync(w => w.UserId == user.Id);
                if (auth != null)
                    _dBContext.Auths.Remove(auth);
                _dBContext.Users.Remove(user);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteUser error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<User> EditUser(User user)
        {
            try
            {
                _logger.LogInformation($"EditRent {user.Id}");
                var result = await _dBContext.Users.FirstOrDefaultAsync(w => w.Id == user.Id);
                if (result != null)
                {

                    if (result.Role != user.Role && user.Role == UserRole.Admin)
                    {
                        return null;
                    }

                    result.FirstName = user.FirstName;
                    result.SecondName = user.SecondName;
                    await _dBContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"EditUser error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
                return null;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                _logger.LogInformation($"GetUser {id}");
                var rent = await _dBContext.Users.FindAsync(id);
                if (rent != null)
                {
                    return rent;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUser error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
                return null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                _logger.LogInformation("GetUsers");
                return _dBContext.Users.Where(w => w.Role != UserRole.Counterparty);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUsers error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
                return null;
            }
        }
        #endregion
    }
}
