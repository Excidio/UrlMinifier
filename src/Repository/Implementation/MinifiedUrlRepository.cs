using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;

namespace UrlMinifier.Repository.Implementation
{
    public class MinifiedUrlRepository : IMinifiedUrlRepository
    {
        private readonly ApplicationContext _context;

        public MinifiedUrlRepository(ApplicationContext context)
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

        public MinifiedUrl Get(Expression<Func<MinifiedUrl, bool>> expression)
        {
            return _context.MinifiedUrls.SingleOrDefault(expression);
        }

        public IEnumerable<MinifiedUrl> GetAll(Expression<Func<MinifiedUrl, bool>> expression)
        {
            return _context.MinifiedUrls.Where(expression).ToList();
        }
    }
}
