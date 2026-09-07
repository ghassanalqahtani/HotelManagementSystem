using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Floors> Floors { get; set; }
    }
}
