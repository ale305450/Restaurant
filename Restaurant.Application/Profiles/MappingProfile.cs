﻿using AutoMapper;
using Restaurant.Application.DTOs;
using Restaurant.Application.DTOs.BlogPost;
using Restaurant.Application.DTOs.Category;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.DTOs.OrderDetails;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Application.DTOs.Review;
using Restaurant.Application.DTOs.User;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost,BlogPostDto>().ReverseMap();
            CreateMap<BlogPost,CreateBlogPostDto>().ReverseMap();
            CreateMap<BlogPost,UpdateBlogPostDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<MenuItem,MenuItem>().ReverseMap();
            CreateMap<MenuItem,CreateMenuItemDto>().ReverseMap();
            CreateMap<MenuItem,UpdateMenuItemDto>().ReverseMap();

            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<Order,CreateOrderDto>().ReverseMap();
            CreateMap<Order,ChangeOrderStatusDto>().ReverseMap();

            CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
            CreateMap<OrderDetails, CreateOrderDetailsDto>().ReverseMap();
            CreateMap<OrderDetails, UpdateOrderDetailsDto>().ReverseMap();

            CreateMap<Reservation,ReservationDto>().ReverseMap();
            CreateMap<Reservation,CreateReservationDto>().ReverseMap();
            CreateMap<Reservation,ChangeReservationStatusDto>().ReverseMap();
            CreateMap<Reservation,UpdateReservationDto>().ReverseMap();

            CreateMap<Review,ReviewDto>().ReverseMap();
            CreateMap<Review,CreateReviewDto>().ReverseMap();
            CreateMap<Review,UpdateReviewDto>().ReverseMap();

            CreateMap<ApplicationUser, UserDto>().ReverseMap();
 
        }
    }
}
