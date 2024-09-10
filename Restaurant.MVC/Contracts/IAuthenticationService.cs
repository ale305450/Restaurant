namespace Restaurant.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email,string password);
        Task<bool> Register(string firstName, string lastName, string email,string userName, string password);
        Task Logout();
    }
}
