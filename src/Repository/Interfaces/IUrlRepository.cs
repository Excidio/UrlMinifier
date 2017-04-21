using System.Collections.Generic;
using UrlMinifier.Domain;

namespace UrlMinifier.Repository.Interfaces
{
    public interface IUrlRepository
    {
        int Add(Url url);

        void Update(Url url);

        Url Get(int id);

        IEnumerable<Url> GetAll();
    }
}
