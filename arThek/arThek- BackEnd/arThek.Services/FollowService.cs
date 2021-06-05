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
            var followEntity = await _followRepository.GetFollowerByIdsAsync(followDto.MentorId, followDto.MenteeId);
            if (followEntity == null)
            {
                var followAddedToDB = await _followRepository.CreateAsync(followDTO);
                return _mapper.Map<FollowDto>(followAddedToDB);
            }
            else
            {
                followEntity.Unfollowed = false;
                var followUpdated = await _followRepository.UpdateAsync(followEntity);
                return _mapper.Map<FollowDto>(followUpdated);
            }

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

        public async Task<IEnumerable<FollowDto>> GetAllFollowers()
        {
            var followers = (await _followRepository.GetAll()).ToList();
            var followList = _mapper.Map<IEnumerable<FollowDto>>(followers);

            return followList;
        }

        public async Task<IEnumerable<FollowDto>> GetMenteeFollowing(Guid menteeId)
        {
            var followers = (await _followRepository.GetMenteeFollowing(menteeId)).ToList();
            var followList = _mapper.Map<IEnumerable<FollowDto>>(followers);

            return followList;
        }

        public async Task<FollowDto> DeleteAsync(Guid mentorId, Guid menteeId)
        {
            var followEntity = await _followRepository.GetFollowerByIdsAsync(mentorId, menteeId);
            if (followEntity == null || followEntity.Unfollowed == true)
                throw new NotFoundException("The follower not found");

            followEntity.Unfollowed = true;
            var updatedTraining = await _followRepository.UpdateAsync(followEntity);

            return _mapper.Map<FollowDto>(updatedTraining);
        }
    }
}
