using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Contracts.Presistence
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem>
    {
        Task<MenuItem> GetMenuItemRequestWithDetails(int id);
        Task<List<MenuItem>> GetMenuItemRequestWithDetails();
    }
}
