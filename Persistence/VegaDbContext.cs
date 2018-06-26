using System.Collections.Generic;
using ASP_Angular.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP_Angular.Persistence {
    public class VegaDbContext : DbContext {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { set; get; }
        public DbSet<Vihicle>  Vihicles { get; set; }
        public DbSet<VihicleFeature> VihicleFeatures { get; set; }

        public VegaDbContext (DbContextOptions<VegaDbContext> options) : base (options) {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<VihicleFeature> ().HasKey (vf => new { vf.VihicleId, vf.FeatureID });
        }
    }
}