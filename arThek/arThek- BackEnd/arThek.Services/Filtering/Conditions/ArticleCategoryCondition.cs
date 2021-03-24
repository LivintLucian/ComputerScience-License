using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.Services.Filtering.Conditions
{
    public class ArticleCategoryCondition : IArticleConditions
    {
        private string _articleCategory;
        public void AddFilterOptions(IFilterArticles options)
        {
            _articleCategory = options.Category;
        }

        public bool IsSatisfied(Article article)
        {
            return _articleCategory == article.Category;
        }
    }
}
