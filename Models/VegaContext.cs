using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace vega.Models
{
    public class VegaContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public VegaContext(DbContextOptions<VegaContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder ModelBuilder){
            ModelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }
    }
}