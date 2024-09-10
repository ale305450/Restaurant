using Restaurant.MVC.Models.BlogPost;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IBlogPostService
    {
        Task<List<BlogPostVM>> GetBlogPosts();
        Task<BlogPostVM> GetBlogPostDetails(int id);
        Task<Response<int>> CreateBlogPost(CreateBlogPostVM blogPost);
        Task<Response<int>> UpdateBlogPost(int id, BlogPostVM blogPost);
        Task<Response<int>> DeleteBlogPost(int id);

    }
}
