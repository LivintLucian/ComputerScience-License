using arThek.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arThek.Infrastructure.Configurations
{
    public class MentorArticleConfiguration : IEntityTypeConfiguration<MentorArticle>
    {
        public void Configure(EntityTypeBuilder<MentorArticle> builder)
        {
            builder.HasKey(ma => new { ma.ArticleId, ma.MentorId });

            builder.HasOne(m => m.Mentor)
                .WithMany(ma => ma.MentorArticles)
                .HasForeignKey(mk => mk.MentorId);

            builder.HasOne(a => a.Article)
                .WithMany(ma => ma.MentorArticles)
                .HasForeignKey(ak => ak.ArticleId);
        }
    }
}
