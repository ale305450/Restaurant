using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Presistence.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public MenuItemRepository(RestaurantDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
