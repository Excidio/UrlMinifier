using UrlMinifier.Domain;

namespace UrlMinifier.WebApp.Models
{
    public class MinifiedUrlModel
    {
        public MinifiedUrlModel(MinifiedUrl minifiedUrl)
        {
            OriginalUrl = minifiedUrl.OriginalUrl;
            ShortUrl = minifiedUrl.ShortUrl;
            ClickCount = minifiedUrl.ClickCount;
            DateCreated = minifiedUrl.DateCreated.ToString("g");
        }

        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public int ClickCount { get; set; }

        public string DateCreated { get; set; }
    }
}
