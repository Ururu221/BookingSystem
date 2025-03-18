using BookingSystem_web_api.Models;
using BookingSystem_web_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem_web_api.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _db = null!;

        public RoomRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<RoomModel> CreateRoomAsync(RoomModel room)
        {
            room.Id = Guid.NewGuid();
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            return room;
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            var room = _db.Rooms.FirstOrDefault(r => r.Id == id) ?? throw new Exception("Room with this ID was not found");
            _db.Rooms.Remove(room);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomModel>> GetAllAsync()
        {
            return  await _db.Rooms.Include(r => r.Reservation).ToListAsync();
        }

        public async Task<RoomModel> GetByIdAsync(Guid id)
        {
            var room = await _db.Rooms.Include(r => r.Reservation).FirstOrDefaultAsync(r => r.Id == id);
            return room ?? throw new Exception("Room with this ID was not found");
        }

        public async Task<RoomModel> UpdateRoomAsync(RoomModel room)
        {
            var oldRoom = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id) ?? throw new Exception("Room with this ID was not found");

            oldRoom.Price = room.Price;
            oldRoom.HumanCapacity = room.HumanCapacity;
            oldRoom.Address = room.Address;
            oldRoom.RoomType = room.RoomType;
            oldRoom.Reservation = room.Reservation;
            oldRoom.IsAvailable = room.IsAvailable;

            await _db.SaveChangesAsync();
            return oldRoom;
        }
    }
}
