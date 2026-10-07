using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Application.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomDto> GetAllRooms();
        UpdateRoomDto GetRoomById(int id);
        RoomDto GetRoomDetailsById(int id);
        void CreateRoom(CreateRoomDto dto);
        void UpdateRoom(UpdateRoomDto dto);
        void DeleteRoom(int id);

       
        Rooms GetRoomEntityById(int id);
        List<HotelImage> GetRoomImages(int roomId);
        void AddRoomImage(HotelImage hotelImage);
    }
}
