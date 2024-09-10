using Restaurant.MVC.Models.Category;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryDetails(int id);
        Task<Response<int>> CreateCategory(CreateCategoryVM category);
        Task<Response<int>> UpdateCategory(int id, CategoryVM category);
        Task<Response<int>> DeleteCategory(int id);

    }
}
