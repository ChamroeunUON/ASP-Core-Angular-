using System.Collections.Generic;
using ASP_Angular.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP_Angular.Persistence {
    public class VegaDbContext : DbContext {
         public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { set; get; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }
        

        public VegaDbContext (DbContextOptions<VegaDbContext> options) : base (options) {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {          
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
                    new{vf.VehicleId,vf.FeatureId});
        }
    }
}