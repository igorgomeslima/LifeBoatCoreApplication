using LifeBoatCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBoatCoreApplication.DTOs.Home
{
    public class HomeIndexDTO
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string DefaultMessage { get; set; }
    }
}
