using HotelManagementSystem.Infrastructure.Data;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly AppDbContext _db;

        public FloorRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Floors> GetAllFloors()
        {
            return _db.Floors.ToList();
        }

        public Floors GetFloorById(int id)
        {
            return _db.Floors.FirstOrDefault(f => f.Id == id);
        }

        public void AddFloor(Floors floor)
        {
            _db.Floors.Add(floor);
        }

        public void UpdateFloor(Floors floor)
        {
            _db.Floors.Update(floor);
        }

        public void DeleteFloor(int id)
        {
            var floor = _db.Floors.Find(id);
            if (floor != null)
            {
                _db.Floors.Remove(floor);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
