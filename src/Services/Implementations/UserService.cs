using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;
using UrlMinifier.Services.Interfaces;

namespace UrlMinifier.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string ipAddress)
        {
            var user = new User
            {
                IpAddress = ipAddress
            };

            _userRepository.Add(user);

            return user;
        }

        public User GetUser(string ipAddress)
        {
            return _userRepository.Get(p => p.IpAddress == ipAddress);
        }
    }
}
