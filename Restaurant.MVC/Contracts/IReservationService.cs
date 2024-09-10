using Restaurant.MVC.Models.Reservation;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IReservationService
    {
        Task<List<ReservationVM>> GetReservations();
        Task<ReservationVM> GetReservationDetails(int id);
        Task<Response<int>> CreateReservation(CreateReservationVM reservation);
        Task<Response<int>> UpdateReservation(int id, ReservationVM reservation);
        Task<Response<int>> DeleteReservation(int id);
    }
}
