using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.User;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public UserService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateUser(CreateUserVM user)
        {
            try
            {
                var response = new Response<int>();
                CreateUserDto createUser = _mapper.Map<CreateUserDto>(user);
                var apiResponse = await _client.UserPOSTAsync(createUser);
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

        public async Task<Response<int>> DeleteUser(int id)
        {
            try
            {
                await _client.UserDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<UserVM> GetUserDetails(int id)
        {
            var user = await _client.UserGETAsync(id);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<List<UserVM>> GetUsers()
        {
            var users = await _client.UserAllAsync();
            return _mapper.Map<List<UserVM>>(users);
        }

        public async Task<Response<int>> UpdateUser(int id, UserVM user)
        {
            try
            {
                UpdateUserDto updateUser = _mapper.Map<UpdateUserDto>(user);
                await _client.UserPUTAsync(id, updateUser);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

    }
}
