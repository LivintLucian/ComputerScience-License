using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IFollowService
    {
        Task<FollowDto> CreateAsync(FollowDto followDto);
        Task<FollowDto> GetByIdAsync(Guid id);
        Task<IEnumerable<FollowDto>> GetAllFollowers();
        Task<FollowDto> DeleteAsync(Guid mentorId, Guid menteeId);
        Task<IEnumerable<FollowDto>> GetMenteeFollowing(Guid menteeId);
    }
}
