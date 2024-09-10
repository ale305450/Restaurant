using Restaurant.MVC.Models.User;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IUserService
    {
        Task<List<UserVM>> GetUsers();
        Task<UserVM> GetUserDetails(int id);
        Task<Response<int>> CreateUser(CreateUserVM user);
        Task<Response<int>> UpdateUser(int id, UserVM user);
        Task<Response<int>> DeleteUser(int id);
    }
}
