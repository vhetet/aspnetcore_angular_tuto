using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace vega.Models
{
    public class VegaContext : DbContext
    {
        public VegaContext(DbContextOptions<VegaContext> options)
            : base(options)
        { }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Make> Makes { get; set; }
    }
}