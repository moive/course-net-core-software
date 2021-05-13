using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             PACKAGE MANAGER CONSOLE
             1° Add-Migration InitialCreate
             2° Add-Migration SeeFriendsTable
             3° Update-Database
             */
            modelBuilder.Entity<Friend>().HasData(new Friend() { Id = 1, Name = "Moises", City = Province.Sihuas, Email = "mvelasquez@test.com" });
        }
    }
}
