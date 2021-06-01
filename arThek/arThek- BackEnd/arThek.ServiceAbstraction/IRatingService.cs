using arThek.Entities.Entities;
using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IRatingService
    {
        Task<RatingDto> CreateAsync(RatingDto ratingDto);
        Task<RatingDto> GetByIdAsync(Guid id);
        Task<IEnumerable<RatingDto>> GetAllRatings();

    }
}
