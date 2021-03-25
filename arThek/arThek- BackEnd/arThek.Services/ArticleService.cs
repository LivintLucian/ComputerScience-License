using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleFilterService _articleFilterService;

        public ArticleService(IMapper mapper, 
            IArticleRepository articleRepository,
            IArticleFilterService articleFilterService)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _articleFilterService = articleFilterService;
        }

        public async Task<ArticleDto> CreateAsync(ArticleDto articleDto)
        {
            var articleDTO = _mapper.Map<Article>(articleDto);
            var articleAddedToDB = await _articleRepository.CreateAsync(articleDTO);

            return _mapper.Map<ArticleDto>(articleAddedToDB);
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticles()
        {
            var articles = (await _articleRepository.GetAll()).ToList();
            var articlesList = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            return articlesList;
        }

        public async Task<ArticleDto> GetByIdAsync(Guid id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article is null)
            {
                throw new NotFoundException("This article doesn't exist!");
            }

            return _mapper.Map<ArticleDto>(article);
        }

        public async Task<List<ViewArticleDto>> GetFilteredTrainings(ArticleParametersDto articleParametersDto)
        {
            var mentors = await _articleRepository.GetAll();
            var filterOptions = articleParametersDto.FilterArticlesDto ?? new FilterArticlesDto();

            _articleFilterService.RegisterFilters(filterOptions);

            var filteredMentors = _articleFilterService
                .Execute(mentors)
                .ToList();

            return _mapper.Map<List<ViewArticleDto>>(filteredMentors);
        }

    }
}
