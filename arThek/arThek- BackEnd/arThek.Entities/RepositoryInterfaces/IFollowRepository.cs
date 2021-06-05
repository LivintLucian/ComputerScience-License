using arThek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.Entities.RepositoryInterfaces
{
    public interface IFollowRepository : IGenericRepository<Follow>
    {
        Task<Follow> GetFollowerByIdsAsync(Guid mentorId, Guid menteeId);
        Task<IEnumerable<Follow>> GetMenteeFollowing(Guid menteeId);
    }
}
