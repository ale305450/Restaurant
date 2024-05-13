using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.User
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
