using Microsoft.AspNetCore.Http;
using UrlMinifier.Domain;
using UrlMinifier.Services.Interfaces;
using UrlMinifier.WebApp.Extensions;

namespace UrlMinifier.WebApp.Managers
{
    public class UserManager : IUserManager
    {
        private const string SessionKeyUser = "_User";

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public UserManager(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public User GetUser()
        {
            var user = _httpContextAccessor.HttpContext.Session.Get<User>(SessionKeyUser);
            if (user == null)
            {
                var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                user = _userService.GetUser(ipAddress) ?? _userService.CreateUser(ipAddress);
                _httpContextAccessor.HttpContext.Session.Set(SessionKeyUser, user);
            }

            return user;
        }
    }
}
