using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace arThek.Entities.Entities
{
    public class Article : BaseEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; } 
        public ICollection<MentorArticle> MentorArticles { get; set; }
    }
}
