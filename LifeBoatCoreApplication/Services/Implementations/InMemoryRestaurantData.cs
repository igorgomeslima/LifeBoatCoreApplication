using LifeBoatCoreApplication.Models;
using LifeBoatCoreApplication.Services.Contracts;
using System.Collections.Generic;

namespace LifeBoatCoreApplication.Services.Implementations
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Restoran 1" },
                new Restaurant { Id = 2, Name = "Restoran 2" },
                new Restaurant { Id = 3, Name = "Restoran 3" },
                new Restaurant { Id = 4, Name = "Restoran 4" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
