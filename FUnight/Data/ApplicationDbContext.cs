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
            : base(options){}


       public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<FUnActivity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        
    }
}
