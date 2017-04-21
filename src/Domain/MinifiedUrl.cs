using System;
using System.ComponentModel.DataAnnotations;

namespace UrlMinifier.Domain
{
    public class MinifiedUrl
    {
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public int ClickCount { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateLastUpdated { get; set; }
    }
}
