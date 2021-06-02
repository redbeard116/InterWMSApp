﻿using InterWMSApp.Models;
using InterWMSApp.Services.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using InterWMSApp.Models.AppSettings;

namespace InterWMSApp.Services.AuthServices
{
    internal class AuthService : IAuthService
    {
        #region Fields
        private readonly ILogger<AuthService> _logger;
        private readonly DBContext _dBContext;
        #endregion

        #region Constructor
        public AuthService(ILogger<AuthService> logger,
                           DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        #endregion

        #region IAuthService
        public async Task<User> GetUser(UserAuth user)
        {
            try
            {
                _logger.LogInformation($"Auth in server");
                var result = await _dBContext.Users.FirstOrDefaultAsync(w => w.Login == user.Login && w.Password == user.Password);

                if (result == null)
                    return null;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUser error.\nMessage: {ex.Message}\nStack trace: {ex.StackTrace}");
                return null;
            }
        }
        #endregion
    }
}
