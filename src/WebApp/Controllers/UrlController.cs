using Microsoft.AspNetCore.Mvc;

namespace UrlMinifier.WebApp.Controllers
{
    public class UrlController : Controller
    {
        public string GetHistory()
        {
            return "[  {    \"originalUrl\": \"https://www.yandex.ru/\",    \"shortUrl\": \"http://ttt.com\",    \"clickCount\": 1,    \"dateCreated\": \"01.01.0001\"  },  {    \"originalUrl\": \"https://www.google.ru/\",    \"shortUrl\": \"http://ttt.com\",    \"clickCount\": 2,    \"dateCreated\": \"00.00.2000\"  },  {    \"originalUrl\": \"https://translate.google.ru/\",    \"shortUrl\": \"http://ttt.com\",    \"clickCount\": 0,    \"dateCreated\": \"20.04.2017\"  }]";
        }
    }
}
