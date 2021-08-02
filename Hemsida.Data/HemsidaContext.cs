using Hemsida.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hemsida.Data
{
    public class HemsidaDbContext : DbContext
    {
        public HemsidaDbContext(DbContextOptions<HemsidaDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
