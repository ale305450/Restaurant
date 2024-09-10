using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.OrderDetails;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class OrderDetailsService : BaseHttpService, IOrderDetailsService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public OrderDetailsService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateOrderDetails(CreateOrderDetailsVM orderDetails)
        {
            try
            {
                var response = new Response<int>(); 
                CreateOrderDetailsDto createOrderDetails = _mapper.Map<CreateOrderDetailsDto>(orderDetails);
                var apiResponse = await _client.OrderDetailsPOSTAsync(createOrderDetails);
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

        public async Task<Response<int>> DeleteOrderDetails(int id)
        {
            try
            {
                await _client.OrderDetailsDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<OrderDetailsVM> GetOrderDetailsDetails(int id)
        {
            var orderDetails = await _client.OrderDetailsGETAsync(id);
            return _mapper.Map<OrderDetailsVM>(orderDetails);
        }

        public async Task<List<OrderDetailsVM>> GetOrdersDetails(int id)
        {
            var ordersDetails = await _client.OrderDetailsAllAsync(id);
            return _mapper.Map<List<OrderDetailsVM>>(ordersDetails);
        }

        public async Task<Response<int>> UpdateOrderDetails(int id, OrderDetailsVM orderDetails)
        {
            try
            {
                UpdateOrderDetailsDto updateOrderDetails = _mapper.Map<UpdateOrderDetailsDto>(orderDetails);
                await _client.OrderDetailsPUTAsync(id, updateOrderDetails);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
