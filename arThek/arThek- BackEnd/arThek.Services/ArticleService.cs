using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IArticleFilterService _articleFilterService;

        public ArticleService(IMapper mapper,
            IArticleRepository articleRepository,
            IArticleFilterService articleFilterService,
            IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _articleFilterService = articleFilterService;
            _ratingRepository = ratingRepository;
        }

        public async Task<ArticleDto> CreateAsync(CreateArticleDto createArticleDto)
        {
            var articleDTO = _mapper.Map<Article>(createArticleDto);
            articleDTO.Image = GetByteFileArray(createArticleDto.Image);
            var articleAddedToDB = await _articleRepository.CreateAsync(articleDTO);

            return _mapper.Map<ArticleDto>(articleAddedToDB);
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticles()
        {
            var articles = (await _articleRepository.GetAll()).ToList();
            for (int article = 0; article < articles.Count(); ++article)
            {
                await UpdateArticleRating(articles[article].Id);
            }
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

            var filteredArticles = _articleFilterService
                .Execute(mentors)
                .ToList();

            return _mapper.Map<List<ViewArticleDto>>(filteredArticles);
        }

        public async Task<ArticleDto> UpdateArticleRating(Guid id)
        {
            var articleEntity = await _articleRepository.GetByIdAsync(id);
            if (articleEntity is null)
                throw new NotFoundException("The article wasn't found!");

            var ratings = await _ratingRepository.GetAll().ContinueWith(async result =>
            {
                var ratingsFromTask = result.Result;
                var ratingList = ratingsFromTask.Where(x => x.ArticleId == id).Select(r => r.RatingValue);
                articleEntity.Rating = (int)ratingList.Average();
            });
            var articleUpdated = await _articleRepository.UpdateAsync(articleEntity);
            return _mapper.Map<ArticleDto>(articleUpdated);
        }

        private byte[] GetByteFileArray(IFormFile byteFile)
        {
            byte[] array = null;
            if (byteFile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byteFile.CopyTo(ms);
                    array = ms.ToArray();
                }
            }

            return array;
        }
    }
}
