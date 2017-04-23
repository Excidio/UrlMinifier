using System.Linq;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;

namespace UrlMinifier.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UrlMinifierContext _context;

        public UserRepository(UrlMinifierContext context)
        {
            _context = context;
        }

        public int Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public User Get(string ipAddress)
        {
            return _context.Users.SingleOrDefault(s => s.IpAddress == ipAddress);
        }
    }
}
