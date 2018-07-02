using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeBoatCoreApplication.Models;
using LifeBoatCoreApplication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeBoatCoreApplication.Pages
{
    public class IndexModel : PageModel
    {
        private  IRestaurantData _restaurantData { get; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IndexModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Restaurants = _restaurantData.GetAll();
        }
    }
}