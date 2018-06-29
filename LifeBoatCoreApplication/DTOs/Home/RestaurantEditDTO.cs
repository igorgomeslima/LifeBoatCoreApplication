using LifeBoatCoreApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace LifeBoatCoreApplication.DTOs.Home
{
    public class RestaurantEditDTO
    {
        [Required, MaxLength(10)]
        public string Name { get; set; }
        public CuisineType CuisineType { get; set; }
    }
}
