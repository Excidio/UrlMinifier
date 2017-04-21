using System;

namespace UrlMinifier.Domain
{
    public class Url
    {
        public int Id { get; set; }

        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public int ClickCount { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatorIpAddress { get; set; }

        public DateTime DateLastUpdated { get; set; }
    }
}
