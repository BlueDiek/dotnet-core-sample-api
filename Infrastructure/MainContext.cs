using System;
using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Consulting.Infrastructure.DataAccess
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
