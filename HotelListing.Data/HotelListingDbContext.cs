using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO.IsolatedStorage;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : IdentityDbContext<ApiUser>
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());

           // modelBuilder.Entity<Country>().HasData(
           //     new Country
           //     {
           //         Id = 1,
           //         Name = "Jamaica",
           //         ShortName = "JM"
           //     },
           //     new Country
           //     {
           //         Id = 2,
           //         Name = "Bahamas",
           //         ShortName = "BS"
           //     },
           //     new Country
           //     {
           //         Id = 3,
           //         Name = "Cayman Island",
           //         ShortName = "CI"
           //     }
           //);

            //modelBuilder.Entity<Hotel>().HasData(
            //    new Hotel
            //    {
            //        Id = 1,
            //        Name = "Sandals Resort and Spa",
            //        Address = "Negril",
            //        CountryId = 1,
            //        Rating = 4.5
            //    },
            //    new Hotel
            //    {
            //        Id = 2,
            //        Name = "Comfort Suites",
            //        Address = "George Town",
            //        CountryId = 3,
            //        Rating = 4.3
            //    },
            //    new Hotel
            //    {
            //        Id = 3,
            //        Name = "Grand Palladium",
            //        Address = "Nassau",
            //        CountryId = 2,
            //        Rating = 4
            //    }
            //);

        }
    }

    //********* FIX SCAFFOLDING ERROR AFTER ARCHITECTURAL CHANGES ************************
    public class HotelListingDbContextFactory : IDesignTimeDbContextFactory<HotelListingDbContext>
    {
        public HotelListingDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .Build();

            var optionsBuilder = new DbContextOptionsBuilder<HotelListingDbContext>();
            var conn = config.GetConnectionString("HotelListingDbConnectionString");
            optionsBuilder.UseSqlServer(conn);
            return new HotelListingDbContext(optionsBuilder.Options);
        }
    }
}
