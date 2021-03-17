using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class MentorArticle : BaseEntity
    {
        public Guid MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
