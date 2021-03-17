using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace arThek.Infrastructure.Repositories
{
    public class BaseUserRepository : IBaseUserRepository
    {
        private readonly arThekContext _arThekContext;

        public BaseUserRepository(arThekContext arThekContext)
        {
            _arThekContext = arThekContext;
        }
        public async Task<Mentor> GetByEmailAddressAsync(string emailAddress)
        {
            return await _arThekContext.Mentors.SingleOrDefaultAsync(e => e.Email == emailAddress);
        }
    }
}
