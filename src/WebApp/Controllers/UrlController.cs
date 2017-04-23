using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UrlMinifier.Services.Interfaces;
using UrlMinifier.WebApp.Managers;
using UrlMinifier.WebApp.Models;

namespace UrlMinifier.WebApp.Controllers
{
    public class UrlController : Controller
    {
        private readonly IMinifiedUrlService _minifiedUrlService;
        private readonly IUserManager _userManager;

        public UrlController(IMinifiedUrlService minifiedUrlService, IUserManager userManager)
        {
            _minifiedUrlService = minifiedUrlService;
            _userManager = userManager;
        }

        public IActionResult GetHistory()
        {
            object result = null;

            var user = _userManager.GetUser();
            if (user != null)
            {
                result = _minifiedUrlService.GetAllMinifiedUrl(user).Select(p => new MinifiedUrlModel(p));
            }
            
            return Json(result);
        }

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
            var urlPrefix = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

            return Json(_minifiedUrlService.MinifyUrl(urlPrefix, _userManager.GetUser(), originalUrl.Url));
        }
    }
}
