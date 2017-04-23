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

        private readonly IMinifiedUrlRepository _urlRepository;

        public MinifiedUrlService(IMinifiedUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        #region IUrlService

        public string MinifyUrl(string urlPrefix, User user, string originalUrl)
        {
            var minifiedUrl = CreateInitialMinifiedUrl(user, originalUrl);

            return CreateShortUrl(urlPrefix, minifiedUrl).ShortUrl;
        }

        public string GetOriginalUrl(string shortUrl)
        {
            var result = string.Empty;

            var minifiedUrlId = BijectiveAlgorithm.Decode(shortUrl);
            var minifiedUrl = _urlRepository.Get(p => p.Id == minifiedUrlId);
            if (minifiedUrl != null)
            {
                IncreaseClickCount(minifiedUrl);
                result = minifiedUrl.OriginalUrl;
            }

            return result;
        }

        public IEnumerable<MinifiedUrl> GetAllMinifiedUrl(User user)
        {
            return _urlRepository.GetAll(u => u.UserId == user.Id);
        }

        #endregion


        private MinifiedUrl CreateInitialMinifiedUrl(Identity user, string originalUrl)
        {
            var url = new MinifiedUrl
            {
                UserId = user.Id,
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

        private void IncreaseClickCount(MinifiedUrl minifiedUrl)
        {
            minifiedUrl.ClickCount++;
            _urlRepository.Update(minifiedUrl);
        }
    }
}
