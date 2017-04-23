using System.Collections.Generic;
using UrlMinifier.Domain;

namespace UrlMinifier.Services.Interfaces
{
    public interface IMinifiedUrlService
    {
        string MinifyUrl(string urlPrefix, User user, string originalUrl);

        string GetOriginalUrl(string shortUrl);

        IEnumerable<MinifiedUrl> GetAllMinifiedUrl(User user);
    }
}
