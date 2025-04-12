using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Data
{
    public class WalksDbContext : DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> options) : base(options)
        {
        }

        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data
            var difficulties = new List<Difficulty>()
                {
                    new Difficulty()
                    {
                        Id = Guid.Parse("e3cb226c-f92b-4699-aed3-5f688ed43baf"),
                        Name = "Easy"
                    },
                    new Difficulty()
                    {
                        Id = Guid.Parse("a4eb412c-cd0b-4fae-93de-5280b7f98cba"),
                        Name = "Medium"
                    },
                    new Difficulty()
                    {
                        Id = Guid.Parse("5cf21b0c-4d90-480b-8ace-dc6da688abd1"),
                        Name = "Hard"


                       
                    }
                };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("e3cb226c-f92b-4699-aed3-5f688ed43baf"),
                    Code = "NI",
                    Name = "North Island",
                    RegionImageUrl = "https://example.com/region1.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("a4eb412c-cd0b-4fae-93de-5280b7f98cba"),
                    Code = "SI",
                    Name = "South Island",
                    RegionImageUrl = "https://example.com/region2.jpg"
                },

                new Region()
                {
                    Id = Guid.Parse("5cf21b0c-4d90-480b-8ace-dc6da688abd1"),
                    Code = "OT",
                    Name = "Other",
                    RegionImageUrl = "https://example.com/region3.jpg"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);


        }
    }
    }


