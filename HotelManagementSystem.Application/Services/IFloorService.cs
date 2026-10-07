using HotelManagementSystem.Application.Dtos;

namespace HotelManagementSystem.Application.Services
{
    public interface IFloorService
    {
        IEnumerable<FloorDto> GetAllFloors();
        UpdateFloorDto GetFloorById(int id);
        FloorDto GetFloorDetailsById(int id);
        void CreateFloor(CreateFloorDto dto);
        void UpdateFloor(UpdateFloorDto dto);
        void DeleteFloor(int id);
    }
}
