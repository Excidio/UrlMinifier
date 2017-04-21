using System;
using Microsoft.AspNetCore.Mvc;
using UrlMinifier.Domain;
using UrlMinifier.Repository;
using UrlMinifier.Services.Interfaces;

namespace UrlMinifier.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IUrlService service)
        {
            service.MinifyUrl("bla");
        }

        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}
