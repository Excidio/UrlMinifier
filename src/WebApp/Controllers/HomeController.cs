using Microsoft.AspNetCore.Mvc;

namespace UrlMinifier.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}
