using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Contracts.Presistence
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem>
    {
    }
}
