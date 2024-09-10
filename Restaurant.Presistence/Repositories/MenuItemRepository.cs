using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presistence.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public MenuItemRepository(RestaurantDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuItem> GetMenuItemRequestWithDetails(int id)
        {
            var menuItem = await _dbContext.MenuItem
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            return menuItem;
        }

        public async Task<List<MenuItem>> GetMenuItemRequestWithDetails()
        {
            var menuItems = await _dbContext.MenuItem
                .Include(m => m.Category).ToListAsync();
            return menuItems;
        }
    }
}
