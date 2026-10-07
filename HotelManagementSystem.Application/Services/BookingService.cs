using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Repositories;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public IEnumerable<BookingDto> GetAllBookings()
        {
            return _bookingRepo.GetAllBookings().Select(b => new BookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice,
                CustomerName = b.Customer != null ? b.Customer.Name : "غير معروف",
                RoomNumber = b.Room != null ? b.Room.RoomNumber : "غير معروف",
                UID = b.UID
            }).ToList();
        }

        public BookingDto GetBookingById(int id)
        {
            var b = _bookingRepo.GetBookingById(id);
            if (b == null) return null;

            return new BookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice,
                CustomerName = b.Customer != null ? b.Customer.Name : "غير معروف",
                RoomNumber = b.Room != null ? b.Room.RoomNumber : "غير معروف",
                UID = b.UID
            };
        }

        public UpdateBookingDto GetBookingForEditById(int id)
        {
            var b = _bookingRepo.GetBookingById(id);
            if (b == null) return null;

            return new UpdateBookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice
            };
        }

        public void CreateBooking(CreateBookingDto dto)
        {
            var booking = new Bookings
            {
                CustomersId = dto.CustomersId,
                RoomsId = dto.RoomsId,
                NumberOfNights = dto.NumberOfNights,
                TotalPrice = dto.TotalPrice
            };
            _bookingRepo.AddBooking(booking);
            _bookingRepo.Save();
        }

        public void UpdateBooking(UpdateBookingDto dto)
        {
            var b = _bookingRepo.GetBookingById(dto.Id);
            if (b != null)
            {
                b.CustomersId = dto.CustomersId;
                b.RoomsId = dto.RoomsId;
                b.NumberOfNights = dto.NumberOfNights;
                b.TotalPrice = dto.TotalPrice;
                _bookingRepo.UpdateBooking(b);
                _bookingRepo.Save();
            }
        }

        public void DeleteBooking(int id)
        {
            _bookingRepo.DeleteBooking(id);
            _bookingRepo.Save();
        }
    }
}
