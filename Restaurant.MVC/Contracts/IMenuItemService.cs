using Restaurant.MVC.Models.MenuItem;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Contracts
{
    public interface IMenuItemService
    {
        Task<List<MenuItemVM>> GetMenuItems();
        Task<MenuItemVM> GetMenuItemDetails(int id);
        Task<Response<int>> CreateMenuItem(CreateMenuItemVM menuItem);
        Task<Response<int>> UpdateMenuItem(int id, MenuItemVM menuItem);
        Task<Response<int>> DeleteMenuItem(int id);
    }
}
