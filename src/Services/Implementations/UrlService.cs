using System;
using UrlMinifier.Domain;
using UrlMinifier.Repository.Interfaces;
using UrlMinifier.Services.Algorithms;
using UrlMinifier.Services.Interfaces;

namespace UrlMinifier.Services.Implementations
{
    public class UrlService : IUrlService
    {
        private static readonly BijectiveAlgorithm BijectiveAlgorithm = new BijectiveAlgorithm();

        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public string MinifyUrl(string url)
        {
            _urlRepository.Add(new Url
            {
                ClickCount = 1,
                OriginalUrl = "qwe",
                ShortUrl = "ewq",
                CreatorIpAddress = "123",
                DateCreated = DateTime.Now,
                DateLastUpdated = DateTime.Now
            });

            return BijectiveAlgorithm.Encode(19158);
        }

        public string GetRealUrl(string minifiedUrl)
        {
            //var a = BijectiveAlgorithm.Decode(minifiedUrl);

            return "https://www.yandex.ru/";
        }
    }
}
