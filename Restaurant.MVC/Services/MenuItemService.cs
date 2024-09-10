using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.MenuItem;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class MenuItemService : BaseHttpService, IMenuItemService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public MenuItemService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateMenuItem(CreateMenuItemVM menuItem)
        {
            try
            {
                var response = new Response<int>();
                CreateMenuItemDto createMenuItem = _mapper.Map<CreateMenuItemDto>(menuItem);
                var apiResponse = await _client.MenuItemPOSTAsync(createMenuItem);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteMenuItem(int id)
        {
            try
            {
                await _client.MenuItemDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<MenuItemVM> GetMenuItemDetails(int id)
        {
            var menuItem = await _client.MenuItemGETAsync(id);
            return _mapper.Map<MenuItemVM>(menuItem);
        }

        public async Task<List<MenuItemVM>> GetMenuItems()
        {
            var menuItems = await _client.MenuItemAllAsync();
            return _mapper.Map<List<MenuItemVM>>(menuItems);
        }

        public async Task<Response<int>> UpdateMenuItem(int id, MenuItemVM menuItem)
        {
            try
            {
                UpdateMenuItemDto updateMenuItem = _mapper.Map<UpdateMenuItemDto>(menuItem);
                await _client.MenuItemPUTAsync(id, updateMenuItem);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
