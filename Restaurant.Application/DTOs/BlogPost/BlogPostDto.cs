using Restaurant.Application.DTOs.Common;
using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.BlogPost
{
    public class BlogPostDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
