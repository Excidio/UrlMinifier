using Xunit;

namespace UrlMinifier.Services.Tests
{
    public class UrlMinifierTests
    {
        private static readonly UrlMinifier UrlMinifier = new UrlMinifier();

        [Theory]
        [InlineData("https://yandex.ru/", "https://yandex.ru/")]
        public void MinifyTest(string url, string expectedUrl)
        {
            var result = UrlMinifier.Minify(url);

            Assert.Equal(expectedUrl, result);
        }
    }
}
