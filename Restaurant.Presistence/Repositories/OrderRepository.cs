using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public OrderRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeOrderStatus(Order order, string status)
        {
            order.Status = status;
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetCurrentUserOrders(string userId)
        {
            var orders = await _dbContext.Order
                           .Include(o => o.User)
                           .Where(userOrder => userOrder.UserId == userId)
                           .ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderRequestWithDetails(int id)
        {
            var order = await _dbContext.Order
                .Include(o=> o.User)
                .FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<List<Order>> GetOrderRequestWithDetails()
        {
            var orders = await _dbContext.Order
                .Include(o => o.User)
                .ToListAsync();
            return orders;
        }
    }
}
