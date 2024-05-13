using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Contracts.Presistence
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<Review> GetReviewRequestWithDetails(int id);
        Task<List<Review>> GetReviewRequestWithDetails();
    }
}
