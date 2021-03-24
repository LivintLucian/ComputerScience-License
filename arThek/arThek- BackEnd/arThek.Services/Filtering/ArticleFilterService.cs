using arThek.Entities.Entities;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.InterfaceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arThek.Services.Filtering
{
    public class ArticleFilterService : IArticleFilterService
    {
        private readonly IEnumerable<IArticleConditions> _articleConditions;

        public ArticleFilterService(IEnumerable<IArticleConditions> articleConditions)
        {
            _articleConditions = articleConditions;
        }
        public void RegisterFilters(IFilterArticles options)
        {
            _articleConditions.ToList().ForEach(c => c.AddFilterOptions(options));
        }
        public IEnumerable<Article> Execute(IEnumerable<Article> articles)
        {
            return articles.Where(m => _articleConditions.All(c => c.IsSatisfied(m))).ToList();
        }

    }
}
