using Microsoft.AspNetCore.Http;
using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class CreateArticleDto
    {
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
