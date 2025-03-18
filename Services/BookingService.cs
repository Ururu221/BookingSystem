using BookingSystem_web_api.Models;
using BookingSystem_web_api.Repositories.Interfaces;
using BookingSystem_web_api.Services.Interfaces;

namespace BookingSystem_web_api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<RoomModel> CreateRoomAsync(RoomModel room)
        {
            return await _roomRepository.CreateRoomAsync(room);
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            await _roomRepository.DeleteRoomAsync(id);
        }

        public async Task<IEnumerable<RoomModel>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllAsync();
        }

        public async Task<RoomModel> GetRoomAsync(Guid id)
        {
            return await _roomRepository.GetByIdAsync(id);
        }

        public async Task<RoomModel> UpdateRoomAsync(RoomModel room)
        {
            return await _roomRepository.UpdateRoomAsync(room);
        }

        public async Task<RoomModel> BookRoomAsync(Guid roomId, Reservation reservation)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);

            // Checking
            bool isAvailable = await IsRoomAvailableAsync(roomId, reservation.From, reservation.To);
            if (!isAvailable)
                throw new Exception("Room is not available for the selected period.");
            
            // Creating reservation
            reservation.Id = Guid.NewGuid(); 
            reservation.RoomId = roomId;
            await _bookingRepository.CreateReservationAsync(reservation);

            //
            room.IsAvailable = await IsRoomAvailableAsync(roomId, reservation.From, reservation.To); 
            await _roomRepository.UpdateRoomAsync(room);

            return room;
        }

        public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime from, DateTime to)
        {
            var reservations = await _bookingRepository.GetAllAsync();
            bool overlapping = reservations.Any(r =>
                r.RoomId == roomId &&
                ((from >= r.From && from < r.To) ||
                 (to > r.From && to <= r.To) ||
                 (from <= r.From && to >= r.To))
            );
            return !overlapping;
        }
    }
}
