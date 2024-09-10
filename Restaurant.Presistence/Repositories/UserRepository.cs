using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presistence.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public UserRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> Get(string id)
        {
            return await _dbContext.Set<ApplicationUser>().FindAsync(id);
        }
    }
}
