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
    public class MentorRepository : GenericRepository<Mentor>, IMentorRepository
    {
        public MentorRepository(arThekContext context) : base(context) { }

        public override async Task<IEnumerable<Mentor>> GetAll()
        {
            return await _dbSet
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }
        public override async Task<Mentor> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(b => b.Basic)
                .Include(s => s.Standard)
                .Include(p => p.Premium)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Mentor> GetLastMentorAdded()
        {
            return await _dbSet
                .OrderByDescending(t => t.UserCreationDate)
                .FirstAsync();
        }
    }
}
