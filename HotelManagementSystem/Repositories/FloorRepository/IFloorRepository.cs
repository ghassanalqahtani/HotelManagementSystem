using System.Collections.Generic;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
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
