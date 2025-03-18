using BookingSystem_web_api.Models;
using BookingSystem_web_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem_web_api.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _db;

        public BookingRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            reservation.Id = Guid.NewGuid();
            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
            return reservation;
        }

        public async Task DeleteReservationAsync(Guid id)
        {
            var reservation = await _db.Reservations.FirstOrDefaultAsync(x => x.Id == id) ?? 
                    throw new Exception("Reservation with this ID was not found");
            _db.Reservations.Remove(reservation);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _db.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(Guid id)
        {
            return await _db.Reservations.FirstOrDefaultAsync(x => x.Id == id) ??
                    throw new Exception("Reservation with this ID was not found");
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            var oldReservation = await _db.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id) ??
                    throw new Exception("Reservation with this ID was not found");

            oldReservation.From = reservation.From;
            oldReservation.To = reservation.To;

            await _db.SaveChangesAsync();

            return oldReservation;
        }
    }
}
