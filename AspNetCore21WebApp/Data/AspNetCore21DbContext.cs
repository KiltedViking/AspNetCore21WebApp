using AspNetCore21WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore21WebApp.Data
{
    //BP - Database context for access to database - also used when adding migrations
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1#create-the-database-context
    public class AspNetCore21DbContext : DbContext
    {
        public AspNetCore21DbContext(DbContextOptions<AspNetCore21DbContext> options) : base(options)
        {
        }


        #region *** Model classes *********************************************
        //BP - classes handled by Entity Framework - and for migrations to create in database
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        #endregion
    }
}
