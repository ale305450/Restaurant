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
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public OrderDetailsRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderDetails> GetOrderDetailsRequestWithDetails(int id)
        {
            var orderDetails = await _dbContext.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id);
            return orderDetails;
        }

        public async Task<List<OrderDetails>> GetOrdersDetailsRequestWithDetails(int id)
        {
            var ordersDetails = await _dbContext.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.MenuItem)
                .Where(o => o.OrderId == id)
                .ToListAsync();
            return ordersDetails;
        }
    }
}
