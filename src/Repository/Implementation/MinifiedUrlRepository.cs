using System.Collections.Generic;
using System.Linq;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;

namespace UrlMinifier.Repository.Implementation
{
    public class MinifiedUrlRepository : IMinifiedUrlRepository
    {
        private readonly UrlMinifierContext _context;

        public MinifiedUrlRepository(UrlMinifierContext context)
        {
            _context = context;
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
