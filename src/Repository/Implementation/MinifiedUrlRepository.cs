using System.Collections.Generic;
using System.Linq;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;

namespace UrlMinifier.Repository.Implementation
{
    public class MinifiedUrlRepository : IMinifiedUrlRepository
    {
        private readonly MinifiedUrlContext _context;

        public MinifiedUrlRepository(MinifiedUrlContext bookContext)
        {
            _context = bookContext;
        }

        public int Add(MinifiedUrl url)
        {
            _context.MinifiedUrls.Add(url);
            _context.SaveChanges();

            return url.Id;
        }

        public void Update(MinifiedUrl url)
        {
            _context.MinifiedUrls.Update(url);
            _context.SaveChanges();
        }

        public MinifiedUrl Get(int id)
        {
            return _context.MinifiedUrls.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<MinifiedUrl> GetAll()
        {
            return _context.MinifiedUrls.ToList();
        }
    }
}
