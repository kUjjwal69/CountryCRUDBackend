using CountryCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we  will now addd on model creating so that, we can add this parameters into the db that what kind or format of data shall be present in the db
            modelBuilder.Entity<Country>(country =>
            {
                country.HasKey(a => a.CountryId); // pk

                country.Property(p => p.CountryName).IsRequired().HasMaxLength(100);

                country.Property(o => o.CountryCode).IsRequired().HasMaxLength(3);
                country.HasIndex(a => a.CountryName).IsUnique();


            });


            modelBuilder.Entity<State>(state =>
            {
                state.HasKey(a => a.StateId);// PK

                state.Property(p => p.StateName).IsRequired().HasMaxLength(100);
                state.Property(o => o.CountryId).IsRequired();

                state.HasOne(c => c.Country)
                .WithMany(a => a.States)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

                state.HasIndex(a => new { a.StateName, a.CountryId }).IsUnique();
            });


            modelBuilder.Entity<City>(city =>
            {
                city.HasKey(a => a.CityId);// PK
                city.Property(p => p.CityName).IsRequired().HasMaxLength(100);
                city.Property(o => o.StateId).IsRequired();
                city.HasOne(c => c.State)
                .WithMany(a => a.Cities)
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Cascade);
                city.HasIndex(c => new { c.CityName, c.StateId })
          .IsUnique();
            });
        }

    }
    }
