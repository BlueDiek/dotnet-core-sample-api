using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ItemMap(modelBuilder);
        }
    }
}
