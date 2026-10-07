using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Infrastructure.Data;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _db;

        public BookingRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Bookings> GetAllBookings()
        {
            return _db.Bookings.Include(b => b.Customer).Include(b => b.Room).ToList();
        }

        public Bookings GetBookingById(int id)
        {
            return _db.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public void AddBooking(Bookings booking)
        {
            _db.Bookings.Add(booking);
        }

        public void UpdateBooking(Bookings booking)
        {
            _db.Bookings.Update(booking);
        }

        public void DeleteBooking(int id)
        {
            var booking = _db.Bookings.Find(id);
            if (booking != null)
            {
                _db.Bookings.Remove(booking);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
