using Restaurant.MVC.Contracts;
using System.Net.Http.Headers;

namespace Restaurant.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _localStorage;
        protected IClient _client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            _localStorage = localStorage;
            _client = client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured", ValidationErrors = ex.Message, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be found", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, try again", Success = false };

            }
        }
        protected void AddBearerToken()
        {
            if(_localStorage.Exisits("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_localStorage.GetStorageValue<string>("token"));
            }
        }
    }
}
