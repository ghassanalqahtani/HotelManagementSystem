using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public interface IFloorRepository
    {
        IEnumerable<Floors> GetAllFloors();
        Floors GetFloorById(int id);
        void AddFloor(Floors floor);
        void UpdateFloor(Floors floor);
        void DeleteFloor(int id);
        void Save();
    }
}
