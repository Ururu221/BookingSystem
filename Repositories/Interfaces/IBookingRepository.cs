using BookingSystem_web_api.Models;

namespace BookingSystem_web_api.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Reservation> GetByIdAsync(Guid id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Guid id);
    }
}
