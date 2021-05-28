using FFI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.DAL
{
    public class FFIContext : DbContext
    {
        public FFIContext(DbContextOptions<FFIContext> options)
            : base(options)
        {
           
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
