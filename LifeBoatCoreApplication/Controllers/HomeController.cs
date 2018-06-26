using LifeBoatCoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeBoatCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Default controller message!");
            var model = new Restaurant { Id = 1, Name = "Restoran 1" };
            //return new ObjectResult(model);
            //return View();
            return View(model);
        }
    }
}
