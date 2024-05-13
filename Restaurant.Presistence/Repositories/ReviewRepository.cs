using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public ReviewRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Review> GetReviewRequestWithDetails(int id)
        {
            var review = await _dbContext.Review
               .Include(r => r.User)
               .FirstOrDefaultAsync(r => r.Id == id);
            return review;
        }

        public async Task<List<Review>> GetReviewRequestWithDetails()
        {
            var reviews = await _dbContext.Review
                         .Include(r => r.User)
                         .ToListAsync();
            return reviews;
        }
    }
}
