using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.Order;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class OrderService : BaseHttpService, IOrderService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public OrderService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

      
        public async Task<Response<int>> CreateOrder(CreateOrderVM order)
        {
            try
            {
                var response = new Response<int>();
                CreateOrderDto createOrder = _mapper.Map<CreateOrderDto>(order);
                var apiResponse = await _client.OrderPOSTAsync(createOrder);
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

        public async Task<Response<int>> DeleteOrder(int id)
        {
            try
            {
                await _client.OrderDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<OrderVM>> GetOrders()
        {
            var orders = await _client.OrderAllAsync();
            return _mapper.Map<List<OrderVM>>(orders);
        }

        public async Task<List<OrderVM>> GetUserOrders(string userId)
        {
            var orders = await _client.OrderGET2Async(userId);
            return _mapper.Map<List<OrderVM>>(orders);
        }

        public async Task<Response<int>> ChangeOrderStatus(int id, ChangeOrderStatusVM orderStatus)
        {
            try
            {
                ChangeOrderStatusDto changeOrderStatus = _mapper.Map<ChangeOrderStatusDto>(orderStatus);
                await _client.ChangestatusAsync(id, changeOrderStatus);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

    }
}
