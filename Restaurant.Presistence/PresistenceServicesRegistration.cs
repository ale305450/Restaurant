using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Presistence.Repositories;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Presistence
{
    public static class PresistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePresistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>(option =>
            option.UseSqlServer(
                configuration.GetConnectionString("RestaurantConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddScoped<IBlogPostRepository,BlogPostRepository>();
            services.AddScoped<IMenuItemRepository,MenuItemRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IReservationRepository,ReservationRepository>();
            services.AddScoped<IReviewRepository,ReviewRepository>();
            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }
    }
}
