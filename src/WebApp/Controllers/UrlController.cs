using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UrlMinifier.Services.Interfaces;
using UrlMinifier.WebApp.Models;


namespace UrlMinifier.WebApp.Controllers
{
    public class UrlController : Controller
    {
        private readonly IMinifiedUrlService _minifiedUrlService;
        private readonly IUserService _userService;

        public UrlController(IMinifiedUrlService minifiedUrlService, IUserService userService)
        {
            _minifiedUrlService = minifiedUrlService;
            _userService = userService;
        }

        public IActionResult GetHistory()
        {
            object result = null;

            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var user = _userService.GetUser(ipAddress);

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

            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var user = _userService.GetUser(ipAddress) ?? _userService.CreateUser(ipAddress);
            

            return Json(_minifiedUrlService.MinifyUrl(urlPrefix, user, originalUrl.Url));
        }
    }
}
