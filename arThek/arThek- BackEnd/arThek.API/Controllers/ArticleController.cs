using System;
using System.Threading.Tasks;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace arThek.API.Controllers
{
    [Route("arThek/news")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("publish-article")]
        public async Task<IActionResult> Create([FromForm] CreateArticleDto articleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var articleCreated = await _articleService.CreateAsync(articleDto);

            return CreatedAtAction(nameof(GetById), new { id = articleCreated.Id }, articleCreated);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetById(Guid id)
        {
            return await _articleService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticlesAsync()
        {
            var articlesList = await _articleService.GetAllArticles();

            return Ok(articlesList);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<ViewArticleDto>> Get(
            [FromBody] ArticleParametersDto articleParameters)
        {
            var allMentorsInPage = await _articleService.GetFilteredTrainings(articleParameters);

            return Ok(allMentorsInPage);
        }
    }
}
