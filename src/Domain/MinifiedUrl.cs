using System;

namespace UrlMinifier.Domain
{
    public class MinifiedUrl : Identity
    {
        public int UserId { get; set; }

        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public int ClickCount { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateLastUpdated { get; set; }

        public User User { get; set; }
    }
}
