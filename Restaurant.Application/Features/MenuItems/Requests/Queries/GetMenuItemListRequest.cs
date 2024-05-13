﻿using MediatR;
using Restaurant.Application.DTOs.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.MenuItems.Requests.Queries
{
    public class GetMenuItemListRequest : IRequest<List<MenuItemDto>>
    {
    }
}
