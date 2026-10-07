using HotelManagementSystem.Application.Dtos;

namespace HotelManagementSystem.Application.Services
{
    public interface IBookingService
    {
        IEnumerable<BookingDto> GetAllBookings();
        BookingDto GetBookingById(int id);
        UpdateBookingDto GetBookingForEditById(int id);
        void CreateBooking(CreateBookingDto dto);
        void UpdateBooking(UpdateBookingDto dto);
        void DeleteBooking(int id);
    }
}
