using LifeBoatCoreApplication.Models;
using LifeBoatCoreApplication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LifeBoatCoreApplication.Controllers 
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            //return Content("Default controller message!");
            //var model = new Restaurant { Id = 1, Name = "Restoran 1" };
            //return new ObjectResult(model);
            //return View();
            var model = _restaurantData.GetAll();
            return View(model);
        }
    }
}
