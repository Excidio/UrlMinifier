using System;
using System.Linq.Expressions;
using UrlMinifier.Domain;

namespace UrlMinifier.Repository.Interfaces
{
    public interface IUserRepository
    {
        int Add(User user);

        User Get(Expression<Func<User, bool>> expression);
    }
}
