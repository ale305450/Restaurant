using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.Category;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public CategoryService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<Response<int>> CreateCategory(CreateCategoryVM category)
        {
            try
            {
                var response = new Response<int>();
                CreateCategoryDto createCategory = _mapper.Map<CreateCategoryDto>(category);
                var apiResponse = await _client.CategoryPOSTAsync(createCategory);
                if(apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var error in apiResponse.Errors)
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

        public async Task<Response<int>> DeleteCategory(int id)
        {
            try
            {
                await _client.CategoryDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<CategoryVM>> GetCategories()
        {
            var categories = await _client.CategoryAllAsync();
            return _mapper.Map<List<CategoryVM>>(categories);
        }

        public async Task<CategoryVM> GetCategoryDetails(int id)
        {
            var category = await _client.CategoryGETAsync(id);
            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<Response<int>> UpdateCategory(int id, CategoryVM category)
        {
            try
            {
                UpdateCategoryDto categoryDto = _mapper.Map<UpdateCategoryDto>(category);
                await _client.CategoryPUTAsync(id, categoryDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
