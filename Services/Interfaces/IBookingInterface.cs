using BookingSystem_web_api.Models;

namespace BookingSystem_web_api.Services.Interfaces
{
    public interface IBooking
    {
        Task<RoomModel> GetRoomAsync(Guid id);

        Task<IEnumerable<RoomModel>> GetAllRoomsAsync();

        Task<RoomModel> CreateRoomAsync(RoomModel room);

        Task<RoomModel> UpdateRoomAsync(RoomModel room);

        Task DeleteRoomAsync(Guid id);

        Task<RoomModel> BookRoomAsync(Guid roomId, Reservation reservation);

        Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime from, DateTime to);
    }
}
