using Microsoft.AspNetCore.Mvc;

namespace UrlMinifier.WebApp.Controllers
{
    public class PartialController : Controller
    {
        public IActionResult AppComponent() => PartialView();

        public IActionResult IndexComponent() => PartialView();

        public IActionResult HistoryComponent() => PartialView();
    }
}
