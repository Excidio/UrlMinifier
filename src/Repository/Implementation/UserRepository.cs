using System;
using System.Linq;
using System.Linq.Expressions;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;

namespace UrlMinifier.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users.SingleOrDefault(expression);
        }
    }
}
