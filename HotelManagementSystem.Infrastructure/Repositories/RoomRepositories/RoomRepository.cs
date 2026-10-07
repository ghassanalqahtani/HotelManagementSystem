using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Infrastructure.Data;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _db;

        public RoomRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Rooms> GetAllRooms()
        {
            return _db.Rooms.Include(r => r.Floor).ToList();
        }

        public Rooms GetRoomById(int id)
        {
            return _db.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public void AddRoom(Rooms room)
        {
            _db.Rooms.Add(room);
        }

        public void UpdateRoom(Rooms room)
        {
            _db.Rooms.Update(room);
        }

        public void DeleteRoom(int id)
        {
            var room = _db.Rooms.Find(id);
            if (room != null)
            {
                _db.Rooms.Remove(room);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
