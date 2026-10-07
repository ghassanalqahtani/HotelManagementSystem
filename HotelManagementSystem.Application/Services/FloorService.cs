using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Repositories;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Application.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepo;

        public FloorService(IFloorRepository floorRepo)
        {
            _floorRepo = floorRepo;
        }

        public IEnumerable<FloorDto> GetAllFloors()
        {
            return _floorRepo.GetAllFloors().Select(f => new FloorDto
            {
                Id = f.Id,
                FloorName = f.FloorName,
                FloorNumber = f.FloorNumber,
                UID = f.UID
            }).ToList();
        }

        public UpdateFloorDto GetFloorById(int id)
        {
            var f = _floorRepo.GetFloorById(id);
            if (f == null) return null;

            return new UpdateFloorDto
            {
                Id = f.Id,
                FloorName = f.FloorName,
                FloorNumber = f.FloorNumber
            };
        }

        public FloorDto GetFloorDetailsById(int id)
        {
            var f = _floorRepo.GetFloorById(id);
            if (f == null) return null;

            return new FloorDto
            {
                Id = f.Id,
                FloorName = f.FloorName,
                FloorNumber = f.FloorNumber,
                UID = f.UID
            };
        }

        public void CreateFloor(CreateFloorDto dto)
        {
            var floor = new Floors
            {
                FloorName = dto.FloorName,
                FloorNumber = dto.FloorNumber
            };
            _floorRepo.AddFloor(floor);
            _floorRepo.Save();
        }

        public void UpdateFloor(UpdateFloorDto dto)
        {
            var f = _floorRepo.GetFloorById(dto.Id);
            if (f != null)
            {
                f.FloorName = dto.FloorName;
                f.FloorNumber = dto.FloorNumber;
                _floorRepo.UpdateFloor(f);
                _floorRepo.Save();
            }
        }

        public void DeleteFloor(int id)
        {
            _floorRepo.DeleteFloor(id);
            _floorRepo.Save();
        }
    }
}
