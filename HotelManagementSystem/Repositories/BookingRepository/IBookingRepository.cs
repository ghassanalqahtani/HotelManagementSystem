using System.Collections.Generic;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
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
