using arThek.Entities.BaseEntities;

namespace arThek.Entities.Entities
{
    public class MentorshipPackage : BaseEntity
    {
        public string Title { get; set; }
        public string MentorshipPeriod { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
