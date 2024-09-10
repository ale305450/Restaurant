using AutoMapper;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.BlogPost;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC.Services
{
    public class BlogPostService : BaseHttpService, IBlogPostService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public BlogPostService(ILocalStorageService localStorageService,
            IMapper mapper,
            IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<Response<int>> CreateBlogPost(CreateBlogPostVM blogPost)
        {
            try
            {
                var response = new Response<int>();
                CreateBlogPostDto createBlogPost = _mapper.Map<CreateBlogPostDto>(blogPost);
                var apiResponse = await _client.BlogPostPOSTAsync(createBlogPost);
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

        public async Task<Response<int>> DeleteBlogPost(int id)
        {
            try
            {
                await _client.BlogPostDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<BlogPostVM> GetBlogPostDetails(int id)
        {
            var blogPost = await _client.BlogPostGETAsync(id);
            return _mapper.Map<BlogPostVM>(blogPost);
        }

        public async Task<List<BlogPostVM>> GetBlogPosts()
        {
            var blogPosts = await _client.BlogPostAllAsync();
            return _mapper.Map<List<BlogPostVM>>(blogPosts);
        }

        public async Task<Response<int>> UpdateBlogPost(int id, BlogPostVM blogPost)
        {
            try
            {
                UpdateBlogPostDto blogPostDto = _mapper.Map<UpdateBlogPostDto>(blogPost);
                await _client.BlogPostPUTAsync(id, blogPostDto);
                return new Response<int> { Success= true };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
