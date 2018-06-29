using LifeBoatCoreApplication.Data;
using LifeBoatCoreApplication.Models;
using LifeBoatCoreApplication.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBoatCoreApplication.Services.Implementations
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly LifeBoatCoreApplicationDbContext _context;

        public SqlRestaurantData(LifeBoatCoreApplicationDbContext context)
        {
            _context = context;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(fo => fo.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(ob => ob.Name);
        }
    }
}
