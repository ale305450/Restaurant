using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.User
{
    public interface IUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
