using AutoMapper;
using Restaurant.MVC.Models.BlogPost;
using Restaurant.MVC.Models.Category;
using Restaurant.MVC.Models.MenuItem;
using Restaurant.MVC.Models.Order;
using Restaurant.MVC.Models.OrderDetails;
using Restaurant.MVC.Models.Reservation;
using Restaurant.MVC.Models.Review;
using Restaurant.MVC.Models.User;
using Restaurant.MVC.Services.Base;

namespace Restaurant.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BlogPostDto, BlogPostVM>().ReverseMap();
            CreateMap<CreateBlogPostDto, CreateBlogPostVM>().ReverseMap();

            CreateMap<CategoryDto, CategoryVM>().ReverseMap();
            CreateMap<CreateCategoryDto, CreateCategoryVM>().ReverseMap();

            //CreateMap<MenuItemDto, MenuItemVM>().ReverseMap();
            CreateMap<CreateMenuItemDto, CreateMenuItemVM>().ReverseMap();

            CreateMap<OrderDto, OrderVM>().ReverseMap();
            CreateMap<CreateOrderDto, CreateOrderVM>().ReverseMap();

            CreateMap<OrderDetailsDto, OrderDetailsVM>().ReverseMap();
            CreateMap<CreateOrderDetailsDto, CreateOrderDetailsVM>().ReverseMap();

            CreateMap<ReservationDto, ReservationVM>().ReverseMap();
            CreateMap<CreateReservationDto, CreateReservationVM>().ReverseMap();

            CreateMap<ReviewDto, ReviewVM>().ReverseMap();
            CreateMap<CreateReviewDto, CreateReviewVM>().ReverseMap();

            CreateMap<UserDto, UserVM>().ReverseMap();
            CreateMap<CreateUserDto, CreateUserVM>().ReverseMap();

        }
    }
}