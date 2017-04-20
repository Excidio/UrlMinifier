using Microsoft.AspNetCore.Mvc;

namespace UrlMinifier.WebApp.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult IndexComponent() => PartialView();

        public IActionResult HistoryComponent() => PartialView();
    }
}
