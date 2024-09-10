using Restaurant.MVC.Models.OrderDetails;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetailsVM>> GetOrdersDetails(int id);
        Task<OrderDetailsVM> GetOrderDetailsDetails(int id);
        Task<Response<int>> CreateOrderDetails(CreateOrderDetailsVM orderDetails);
        Task<Response<int>> UpdateOrderDetails(int id, OrderDetailsVM orderDetails);
        Task<Response<int>> DeleteOrderDetails(int id);
    }
}
