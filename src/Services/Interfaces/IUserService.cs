using UrlMinifier.Domain;

namespace UrlMinifier.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(string ipAddress);

        User GetUser(string ipAddress);
    }
}
