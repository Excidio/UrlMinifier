using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UrlMinifier.Services.Interfaces;
using UrlMinifier.WebApp.Models;

namespace UrlMinifier.WebApp.Controllers
{
    public class UrlController : Controller
    {
        private readonly IMinifiedUrlService _minifiedUrlService;

        public UrlController(IMinifiedUrlService minifiedUrlService)
        {
            _minifiedUrlService = minifiedUrlService;
        }

        public IActionResult GetHistory() => Json(_minifiedUrlService.GetAllMinifiedUrl().Select(p => new MinifiedUrlModel(p)));

        public IActionResult Index(string shortUrl)
        {
            var originalUrl = _minifiedUrlService.GetOriginalUrl(shortUrl);
            if (string.IsNullOrWhiteSpace(originalUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(originalUrl);
        }

        [HttpPost]
        public IActionResult Minify([FromBody]MinifyModel originalUrl)
        {
            return Json(_minifiedUrlService.MinifyUrl($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}", originalUrl.Url));
        }
    }
}
