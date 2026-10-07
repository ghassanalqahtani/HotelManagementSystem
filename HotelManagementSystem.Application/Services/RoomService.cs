using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Repositories;
using HotelManagementSystem.Infrastructure.Data;

namespace HotelManagementSystem.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        private readonly AppDbContext _db; 

        public RoomService(IRoomRepository roomRepo, AppDbContext db)
        {
            _roomRepo = roomRepo;
            _db = db;
        }

        public IEnumerable<RoomDto> GetAllRooms()
        {
            return _roomRepo.GetAllRooms().Select(r => new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                IsAvailable = r.IsAvailable,
                FloorsId = r.FloorsId,
                FloorName = r.Floor != null ? r.Floor.FloorName : "غير محدد",
                UID = r.UID,
                RoomImage = r.RoomImage
            }).ToList();
        }

        public UpdateRoomDto GetRoomById(int id)
        {
            var r = _roomRepo.GetRoomById(id);
            if (r == null) return null;

            return new UpdateRoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                FloorsId = r.FloorsId
            };
        }

        public RoomDto GetRoomDetailsById(int id)
        {
            var r = _roomRepo.GetRoomById(id);
            if (r == null) return null;

            return new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                FloorName = r.Floor != null ? r.Floor.FloorName : "غير محدد",
                UID = r.UID
            };
        }

        public void CreateRoom(CreateRoomDto dto)
        {
            var room = new Rooms
            {
                RoomNumber = dto.RoomNumber,
                RoomType = dto.RoomType,
                PricePerNight = dto.PricePerNight,
                FloorsId = dto.FloorsId,
                IsAvailable = true
            };
            _roomRepo.AddRoom(room);
            _roomRepo.Save();
        }

        public void UpdateRoom(UpdateRoomDto dto)
        {
            var r = _roomRepo.GetRoomById(dto.Id);
            if (r != null)
            {
                r.RoomNumber = dto.RoomNumber;
                r.RoomType = dto.RoomType;
                r.PricePerNight = dto.PricePerNight;
                r.FloorsId = dto.FloorsId;
                _roomRepo.UpdateRoom(r);
                _roomRepo.Save();
            }
        }

        public void DeleteRoom(int id)
        {
            _roomRepo.DeleteRoom(id);
            _roomRepo.Save();
        }

        public Rooms GetRoomEntityById(int id)
        {
            return _roomRepo.GetRoomById(id);
        }

        public List<HotelImage> GetRoomImages(int roomId)
        {
            return _db.HotelImages.Where(e => e.FolderId == roomId).ToList();
        }

        public void AddRoomImage(HotelImage hotelImage)
        {
            _db.HotelImages.Add(hotelImage);
            _db.SaveChanges();
        }
    }
}
