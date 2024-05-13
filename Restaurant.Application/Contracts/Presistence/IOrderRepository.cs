using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Contracts.Presistence
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrderRequestWithDetails(int id);
        Task<List<Order>> GetOrderRequestWithDetails();
        Task ChangeOrderStatus(Order order , string status);
    }
}
