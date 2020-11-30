using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.Entities;

namespace TableTennis.DataAccess.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<TeamMatch> TeamMatch { get; set; }
        public DbSet<Schedule> Schedule { get; set; }


        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Team>()
            //    .HasMany(t => t.TeamMembers)
            //    .WithOne(t => t.Team);
            //builder.Entity<Team>()
            //    .HasMany(t => t.TeamMatches)
            //    .WithOne(t => t.Team);
            //builder.Entity<Schedule>()
            //    .HasMany(t => t.TeamMatches)
            //    .WithOne(t => t.Schedule);

        }


    }
}
