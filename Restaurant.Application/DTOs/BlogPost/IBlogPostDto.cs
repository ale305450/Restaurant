using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.BlogPost
{
    public interface IBlogPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
