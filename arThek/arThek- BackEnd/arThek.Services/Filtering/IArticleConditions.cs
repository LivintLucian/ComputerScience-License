using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.Services.Filtering
{
    public interface IArticleConditions
    {
        void AddFilterOptions(IFilterArticles options);
        bool IsSatisfied(Article article);
    }
}
