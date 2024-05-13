using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presistence.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public ReservationRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ChangeReservationStatus(Reservation reservation, string status)
        {
            reservation.Status = status;
            _dbContext.Entry(reservation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Reservation> GetReservationRequestWithDetails(int id)
        {
            var reservation = await _dbContext.Reservation
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
            return reservation;
        }

        public async Task<List<Reservation>> GetReservationRequestWithDetails()
        {
            var reservations = await _dbContext.Reservation
                .Include(r => r.User)
                .ToListAsync();
            return reservations;
        }
    }
}
