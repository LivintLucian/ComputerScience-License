using arThek.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arThek.Infrastructure.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(x => x.AuthorId);

            builder.HasMany(r => r.Ratings)
                .WithOne(a => a.Article)
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
