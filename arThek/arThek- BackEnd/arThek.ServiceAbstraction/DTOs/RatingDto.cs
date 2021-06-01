using arThek.Entities.Entities;
using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public int RatingValue { get; set; }
    }
}
