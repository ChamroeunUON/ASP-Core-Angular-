using System.Collections.Generic;
using ASP_Angular.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP_Angular.Persistence {
    public class VegaDbContext : DbContext {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { set; get; }
<<<<<<< HEAD
<<<<<<< HEAD
        public DbSet<Vihicle>  Vihicles { get; set; }
        public DbSet<VihicleFeature> VihicleFeatures { get; set; }
=======
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFeature> VihicleFeatures { get; set; }
>>>>>>> 0ef9c1498861fd6d5a41dc4ddcab1f761fa941bb
=======
        public DbSet<Vehicle> Vihicles { get; set; }
        public DbSet<VihicleFeature> VihicleFeatures { get; set; }
>>>>>>> parent of fe27b27... Add API POST UPDATE DELETE

        public VegaDbContext (DbContextOptions<VegaDbContext> options) : base (options) {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
<<<<<<< HEAD
<<<<<<< HEAD
            modelBuilder.Entity<VihicleFeature> ().HasKey (vf => new { vf.VihicleId, vf.FeatureID });
=======
            modelBuilder.Entity<VehicleFeature> ().HasKey (vf =>
                new { vf.VehicleId, vf.FeatureId });
            
>>>>>>> 0ef9c1498861fd6d5a41dc4ddcab1f761fa941bb
=======
            modelBuilder.Entity<VihicleFeature> ().HasKey (vf =>
                new { vf.VihicleId, vf.FeatureId });
>>>>>>> parent of fe27b27... Add API POST UPDATE DELETE
        }
    }
}