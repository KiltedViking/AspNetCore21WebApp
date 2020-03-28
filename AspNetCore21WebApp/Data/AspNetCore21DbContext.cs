using AspNetCore21WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore21WebApp.Data
{
    public class AspNetCore21DbContext : DbContext
    {
        public AspNetCore21DbContext(DbContextOptions<AspNetCore21DbContext> options) : base(options)
        {
        }


        #region *** Model classes *********************************************
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        #endregion
    }
}
