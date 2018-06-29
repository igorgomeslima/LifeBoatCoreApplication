using System.ComponentModel.DataAnnotations;

namespace LifeBoatCoreApplication.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant Name")]
        [Required, MaxLength(10)]
        public string Name { get; set; }
        [Display(Name = "Cuisine Type")]
        public CuisineType CuisineType { get; set; }
    }
}
