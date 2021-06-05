using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Infrastructure.Repositories
{
    public class FollowRepository : GenericRepository<Follow>, IFollowRepository
    {
        public FollowRepository(arThekContext context) : base(context) { }

        public async Task<Follow> GetFollowerByIdsAsync(Guid mentorId, Guid menteeId)
        {
            var data = _dbSet.Select(x => x).ToList();
            
            var el = data.Where(x => x.MentorId.CompareTo(mentorId) == 0 && x.MenteeId.CompareTo(menteeId) == 0).FirstOrDefault();

            return el;
        }

        public async Task<IEnumerable<Follow>> GetMenteeFollowing(Guid menteeId)
        {
            return await _dbSet
                .Where(x => x.MenteeId == menteeId)
                .ToListAsync();
        }
    }
}
