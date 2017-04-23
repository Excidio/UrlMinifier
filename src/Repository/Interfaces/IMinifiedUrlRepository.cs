using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UrlMinifier.Domain;

namespace UrlMinifier.Repository.Interfaces
{
    public interface IMinifiedUrlRepository
    {
        int Add(MinifiedUrl url);

        void Update(MinifiedUrl url);

        MinifiedUrl Get(Expression<Func<MinifiedUrl, bool>> expression);

        IEnumerable<MinifiedUrl> GetAll(Expression<Func<MinifiedUrl, bool>> expression);
    }
}
