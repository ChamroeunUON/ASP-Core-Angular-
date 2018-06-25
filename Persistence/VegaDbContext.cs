using ASP_Angular.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace ASP_Angular.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features {set;get;}
    }
}