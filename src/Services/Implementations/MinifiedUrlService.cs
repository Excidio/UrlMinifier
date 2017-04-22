using System;
using System.Collections.Generic;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;
using UrlMinifier.Services.Algorithms;
using UrlMinifier.Services.Interfaces;

namespace UrlMinifier.Services.Implementations
{
    public class MinifiedUrlService : IMinifiedUrlService
    {
        private static readonly BijectiveAlgorithm BijectiveAlgorithm = new BijectiveAlgorithm();

        private readonly IUrlRepository _urlRepository;

        public MinifiedUrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        #region IUrlService

        public string MinifyUrl(string urlPrefix, string originalUrl)
        {
            var minifiedUrl = CreateInitialMinifiedUrl(originalUrl);

            return CreateShortUrl(urlPrefix, minifiedUrl).ShortUrl;
        }

        public string GetOriginalUrl(string shortUrl)
        {
            var minifiedUrlId = BijectiveAlgorithm.Decode(shortUrl);

            return _urlRepository.Get(minifiedUrlId)?.OriginalUrl;
        }

        public IEnumerable<MinifiedUrl> GetAllMinifiedUrl()
        {
            return _urlRepository.GetAll();
        }

        #endregion


        private MinifiedUrl CreateInitialMinifiedUrl(string originalUrl)
        {
            var url = new MinifiedUrl
            {
                OriginalUrl = originalUrl,
                DateCreated = DateTime.Now
            };

            _urlRepository.Add(url);

            return url;
        }

        private MinifiedUrl CreateShortUrl(string urlPrefix, MinifiedUrl minifiedUrl)
        {
            minifiedUrl.ShortUrl = $"{urlPrefix}/{BijectiveAlgorithm.Encode(minifiedUrl.Id)}";

            _urlRepository.Update(minifiedUrl);

            return minifiedUrl;
        }
    }
}
