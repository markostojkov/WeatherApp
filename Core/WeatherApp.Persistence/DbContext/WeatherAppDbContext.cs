using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Persistence.Entities;

namespace WeatherApp.Persistence.DbContext
{
    public class WeatherAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
