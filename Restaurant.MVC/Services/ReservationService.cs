using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.Reservation;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class ReservationService : BaseHttpService, IReservationService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public ReservationService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateReservation(CreateReservationVM reservation)
        {
            try
            {
                var response = new Response<int>();
                CreateReservationDto createReservation = _mapper.Map<CreateReservationDto>(reservation);
                var apiResponse = await _client.ReservationPOSTAsync(createReservation);
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

        public async Task<Response<int>> DeleteReservation(int id)
        {
            try
            {
                await _client.ReservationDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ReservationVM> GetReservationDetails(int id)
        {
            var reservation = await _client.ReservationGETAsync(id);
            return _mapper.Map<ReservationVM>(reservation);
        }

        public async Task<List<ReservationVM>> GetReservations()
        {
            var reservations = await _client.ReservationAllAsync();
            return _mapper.Map<List<ReservationVM>>(reservations);
        }

        public async Task<Response<int>> UpdateReservation(int id, ReservationVM reservation)
        {
            try
            {
                UpdateReservationDto updateReservation = _mapper.Map<UpdateReservationDto>(reservation);
                await _client.ReservationPUTAsync(id, updateReservation);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

    }
}
