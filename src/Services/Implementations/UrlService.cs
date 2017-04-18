using UrlMinifier.Services.Algorithms;
using UrlMinifier.Services.Interfaces;

namespace UrlMinifier.Services.Implementations
{
    public class UrlService : IUrlService
    {
        private static readonly BijectiveAlgorithm BijectiveAlgorithm = new BijectiveAlgorithm();

        public string MinifyUrl(string url)
        {
            return BijectiveAlgorithm.Encode(19158);
        }

        public string GetRealUrl(string minifiedUrl)
        {
            //var a = BijectiveAlgorithm.Decode(minifiedUrl);

            return "https://www.yandex.ru/";
        }
    }
}
