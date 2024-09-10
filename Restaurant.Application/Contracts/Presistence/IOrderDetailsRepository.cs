using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Contracts.Presistence
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {
        Task<OrderDetails> GetOrderDetailsRequestWithDetails(int id);
        Task<List<OrderDetails>> GetOrdersDetailsRequestWithDetails(int id);
    }
}
