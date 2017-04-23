using UrlMinifier.Domain;

namespace UrlMinifier.Repository.Interfaces
{
    public interface IUserRepository
    {
        int Add(User user);

        User Get(string ipAddress);
    }
}
