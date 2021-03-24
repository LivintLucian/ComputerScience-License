using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;

namespace arThek.Infrastructure.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository 
    {
        public ArticleRepository(arThekContext context) : base(context) { }
    }
}
