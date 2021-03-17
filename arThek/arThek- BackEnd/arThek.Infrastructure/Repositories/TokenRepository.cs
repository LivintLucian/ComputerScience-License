using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace arThek.Infrastructure.Repositories
{
    public class TokenRepository : GenericRepository<Token>, ITokenRepository
    {
        public TokenRepository(arThekContext context) : base(context)
        { }

        public async Task DeleteAsync(Token token)
        {
            _dbSet.Remove(token);
            await _context.SaveChangesAsync();
        }

        public Task<Token> FindByTokenAsync(string token)
        {
            return _dbSet.FirstOrDefaultAsync(t => t.TokenValue == token);
        }
    }
}
