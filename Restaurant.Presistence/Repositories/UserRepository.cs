using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Presistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public UserRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
