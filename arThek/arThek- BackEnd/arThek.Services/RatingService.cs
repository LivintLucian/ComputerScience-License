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
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IMapper mapper, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }

        public async Task<RatingDto> CreateAsync(RatingDto ratingDto)
        {
            var ratingDTO = _mapper.Map<Rating>(ratingDto);
            var mentorAddedToDB = await _ratingRepository.CreateAsync(ratingDTO);

            return _mapper.Map<RatingDto>(mentorAddedToDB);
        }

        public async Task<RatingDto> GetByIdAsync(Guid id)
        {
            var ratingObj = await _ratingRepository.GetByIdAsync(id);

            if (ratingObj is null)
            {
                throw new NotFoundException("This rating doesn't exist!");
            }

            return _mapper.Map<RatingDto>(ratingObj);
        }

        public async Task<IEnumerable<RatingDto>> GetAllRatings()
        {
            var ratings = (await _ratingRepository.GetAll()).ToList();
            var ratingList = _mapper.Map<IEnumerable<RatingDto>>(ratings);

            return ratingList;
        }
    }
}
