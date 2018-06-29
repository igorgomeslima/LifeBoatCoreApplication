using LifeBoatCoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBoatCoreApplication.Data
{
    public class LifeBoatCoreApplicationDbContext : DbContext
    {
        public LifeBoatCoreApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}   
