using CarSharingDomain.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingInfrastructure.Database
{
    public class CarSharingDbContext:IdentityDbContext
    {
        public CarSharingDbContext(DbContextOptions<CarSharingDbContext> options):base(options)
        {
            
        }

        public DbSet<CarProfileModel> CarProfileModels { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CarProfileModel>().OwnsOne(c => c.Characteristics);
            modelBuilder.Entity<CarProfileModel>().OwnsOne(c => c.CarContactDetails);
            modelBuilder.Entity<CarProfileModel>().OwnsOne(c => c.GlobalProfileImage);
        }
    }
}
