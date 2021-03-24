using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;
using System.Collections.Generic;

namespace arThek.ServiceAbstraction
{
    public interface IArticleFilterService
    {
        void RegisterFilters(IFilterArticles options);
        IEnumerable<Article> Execute(IEnumerable<Article> mentors);
    }
}
