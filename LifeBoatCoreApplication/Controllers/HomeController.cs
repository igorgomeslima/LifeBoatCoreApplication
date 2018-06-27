using LifeBoatCoreApplication.DTOs.Home;
using LifeBoatCoreApplication.Models;
using LifeBoatCoreApplication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LifeBoatCoreApplication.Controllers 
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IDefaultResponse _defaultResponse;
        public HomeController(IRestaurantData restaurantData, IDefaultResponse defaultResponse)
        {
            _restaurantData = restaurantData;
            _defaultResponse = defaultResponse;
        }
        public IActionResult Index()
        {
            //return Content("Default controller message!");
            //var model = new Restaurant { Id = 1, Name = "Restoran 1" };
            //return new ObjectResult(model);
            //return View();
            //var model = _restaurantData.GetAll();
            var model = new HomeIndexDTO();
            model.Restaurants = _restaurantData.GetAll();
            model.DefaultMessage = _defaultResponse.GetDefaultResponse();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
