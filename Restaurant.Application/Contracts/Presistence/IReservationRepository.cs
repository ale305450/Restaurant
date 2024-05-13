using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Contracts.Presistence
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<Reservation> GetReservationRequestWithDetails(int id);
        Task<List<Reservation>> GetReservationRequestWithDetails();
        Task ChangeReservationStatus(Reservation reservation, string status);
    }
}
