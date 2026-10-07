using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Bookings> GetAllBookings();
        Bookings GetBookingById(int id);
        void AddBooking(Bookings booking);
        void UpdateBooking(Bookings booking);
        void DeleteBooking(int id);
        void Save();
    }
}
