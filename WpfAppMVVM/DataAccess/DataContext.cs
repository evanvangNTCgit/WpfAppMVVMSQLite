using System.IO;
using Microsoft.EntityFrameworkCore;
using WpfAppMVVM.Models;

namespace WpfAppMVVM.DataAccess
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<User> Users { get; set; }

        public DataContext()
        {
            DbPath = "MvvmVang.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 67890, Name = "Evan", Email = "Evang8@students.ntc.edu", Role = "Employee", CreatedDate = (DateTime.Now.AddDays(-40)) },
                new User { Id = 12345, Name = "John", Email = "John6@students.ntc.edu", Role = "Admin", CreatedDate = (DateTime.Now.AddMonths(-4)) }
                );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var projectRoot = Path.GetFullPath(@"..\..\..");
            var dbPath = Path.Combine(projectRoot, $"{this.DbPath}");

            options.UseSqlite(
                $"Data Source={dbPath}");
        }
    }
}
