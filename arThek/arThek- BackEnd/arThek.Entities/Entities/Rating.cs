using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class Rating : BaseEntity
    {
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }
        public int RatingValue { get; set; }
    }
}
