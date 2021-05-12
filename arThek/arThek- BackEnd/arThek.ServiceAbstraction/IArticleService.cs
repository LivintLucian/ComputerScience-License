using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IArticleService
    {
        Task<ArticleDto> CreateAsync(CreateArticleDto createArticleDto);
        Task<ArticleDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ArticleDto>> GetAllArticles();
        Task<List<ViewArticleDto>> GetFilteredTrainings(ArticleParametersDto articleParameters);
    }
}
