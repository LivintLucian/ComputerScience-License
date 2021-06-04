using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class FollowService : IFollowService
    {
        private readonly IMapper _mapper;
        private readonly IFollowRepository _followRepository;

        public FollowService(IMapper mapper, IFollowRepository followRepository)
        {
            _mapper = mapper;
            _followRepository = followRepository;
        }

        public async Task<FollowDto> CreateAsync(FollowDto followDto)
        {
            var followDTO = _mapper.Map<Follow>(followDto);
            var followAddedToDB = await _followRepository.CreateAsync(followDTO);

            return _mapper.Map<FollowDto>(followAddedToDB);
        }

        public async Task<FollowDto> GetByIdAsync(Guid id)
        {
            var followObj = await _followRepository.GetByIdAsync(id);

            if (followObj is null)
            {
                throw new NotFoundException("This follower doesn't exist!");
            }

            return _mapper.Map<FollowDto>(followObj);
        }

        public async Task<IEnumerable<FollowDto>> GetAllRatings()
        {
            var followers = (await _followRepository.GetAll()).ToList();
            var followList = _mapper.Map<IEnumerable<FollowDto>>(followers);

            return followList;
        }

        public async Task<FollowDto> DeleteAsync(Guid id)
        {
            var followEntity = await _followRepository.GetByIdAsync(id);
            if (followEntity == null || followEntity.Unfollowed == true)
                throw new NotFoundException("The Mentor not found");

            followEntity.Unfollowed = true;
            var updatedTraining = await _followRepository.UpdateAsync(followEntity);

            return _mapper.Map<FollowDto>(updatedTraining);
        }
    }
}
