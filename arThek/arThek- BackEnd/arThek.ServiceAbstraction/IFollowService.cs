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
        Task<IEnumerable<FollowDto>> GetAllRatings();
        Task<FollowDto> DeleteAsync(Guid id);
    }
}
