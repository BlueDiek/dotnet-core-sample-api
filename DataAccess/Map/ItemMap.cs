using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void ItemMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Item>().ToTable("ITEM");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID");
            map.Property(t => t.Event).HasColumnName("EVENT");
            map.Property(t => t.Timestamp).HasColumnName("TIMESTAMP");
        }
    }
}