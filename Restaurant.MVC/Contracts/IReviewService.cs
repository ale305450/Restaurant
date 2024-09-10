using Restaurant.MVC.Models.Review;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IReviewService
    {
        Task<List<ReviewVM>> GetReviews();
        Task<ReviewVM> GetReviewDetails(int id);
        Task<Response<int>> CreateReview(CreateReviewVM review);
        Task<Response<int>> UpdateReview(int id, ReviewVM review);
    }
}
