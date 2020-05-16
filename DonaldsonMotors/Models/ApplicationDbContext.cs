using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotors.Models.Actors;
using System.Data.Entity;
using DonaldsonMotors.Models.SystemParts;

namespace DonaldsonMotors.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PartUsed> PartsUsed { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}