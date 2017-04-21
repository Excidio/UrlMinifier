using System.Collections.Generic;
using System.Linq;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;

namespace UrlMinifier.Repository.Implementation
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlContext _context;

        public UrlRepository(UrlContext bookContext)
        {
            _context = bookContext;
        }

        public int Add(Url url)
        {
            _context.Urls.Add(url);
            _context.SaveChanges();

            return url.Id;
        }

        public void Update(Url url)
        {
            _context.Urls.Update(url);
            _context.SaveChanges();
        }

        public Url Get(int id)
        {
            return _context.Urls.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Url> GetAll()
        {
            return _context.Urls.ToList();
        }
    }
}
