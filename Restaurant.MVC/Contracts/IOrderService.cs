using Restaurant.MVC.Models.Order;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderVM>> GetOrders();
        Task<List<OrderVM>> GetUserOrders(string userId);
        Task<Response<int>> CreateOrder(CreateOrderVM order);
        Task<Response<int>> ChangeOrderStatus(int id, ChangeOrderStatusVM order);
        Task<Response<int>> DeleteOrder(int id);
    }
}
