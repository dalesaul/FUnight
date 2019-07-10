using System;
using System.Collections.Generic;
using System.Text;
using FUnight.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FUnight.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<FUnActivity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActivityType>()
                .HasData(new ActivityType()
                {
                    Id = 1,
                    Type = "Park"
                },
                new ActivityType()
                {
                    Id = 2,
                    Type = "Dining Out"
                },
                new ActivityType()
                {
                    Id = 3,
                    Type = "BBQ at Home"
                },
                new ActivityType()
                {
                    Id = 4,
                    Type = "Go to Movies"
                },
                new ActivityType()
                {
                    Id = 5,
                    Type = "Sporting Event"
                },
                new ActivityType()
                {
                    Id = 6,
                    Type = "Local Event"
                },
                new ActivityType()
                {
                    Id = 7,
                    Type = "Ritual Sacrifice"
                },
                new ActivityType()
                {
                    Id = 8,
                    Type = "Overthrow the Gov't"
                }
            );

            modelBuilder.Entity<UserGroup>()
                .HasData(new UserGroup()
                {
                    Id = 4,
                    Name = "MMMB group"
                    
                },
                new UserGroup()
                {
                    Id = 2,
                    Name = "Cohort 1"
                },
                new UserGroup()
                {
                    Id = 3,
                    Name = "lunchtime D&D"
                }
            );

        }
    }
}
    