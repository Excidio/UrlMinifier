using System.Collections.Generic;
using UrlMinifier.Domain;

namespace UrlMinifier.Repository.Interfaces
{
    public interface IUrlRepository
    {
        int Add(MinifiedUrl url);

        void Update(MinifiedUrl url);

        MinifiedUrl Get(int id);

        IEnumerable<MinifiedUrl> GetAll();
    }
}
