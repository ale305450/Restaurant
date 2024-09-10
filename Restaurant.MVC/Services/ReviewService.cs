using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.Review;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class ReviewService : BaseHttpService, IReviewService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public ReviewService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateReview(CreateReviewVM review)
        {
            try
            {
                var response = new Response<int>();
                CreateReviewDto createReview = _mapper.Map<CreateReviewDto>(review);
                var apiResponse = await _client.ReviewPOSTAsync(createReview);
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

        public async Task<ReviewVM> GetReviewDetails(int id)
        {
            var review = await _client.ReviewGETAsync(id);
            return _mapper.Map<ReviewVM>(review);
        }

        public async Task<List<ReviewVM>> GetReviews()
        {
            var review = await _client.ReviewAllAsync();
            return _mapper.Map<List<ReviewVM>>(review);
        }

        public async Task<Response<int>> UpdateReview(int id, ReviewVM review)
        {
            try
            {
                UpdateReviewDto updateReview = _mapper.Map<UpdateReviewDto>(review);
                await _client.ReviewPUTAsync(id, updateReview);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
