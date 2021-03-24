using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.ServiceAbstraction.DTOs
{
    public class FilterArticlesDto : IFilterArticles
    {
        public string Category { get; set; }
    }
}
