using BookingSystem_web_api.Models;

namespace BookingSystem_web_api.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<RoomModel> GetByIdAsync(Guid id);
        Task<IEnumerable<RoomModel>> GetAllAsync();
        Task<RoomModel> CreateRoomAsync(RoomModel room);
        Task<RoomModel> UpdateRoomAsync(RoomModel room);
        Task DeleteRoomAsync(Guid id);
    }
}
