using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<Rooms> GetAllRooms();
        Rooms GetRoomById(int id);
        void AddRoom(Rooms room);
        void UpdateRoom(Rooms room);
        void DeleteRoom(int id);
        void Save();
    }
}
