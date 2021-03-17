using arThek.Entities.Entities;
using System.Threading.Tasks;

namespace arThek.Entities.RepositoryInterfaces
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        public Task<Token> FindByTokenAsync(string token);
        Task DeleteAsync(Token token);
    }
}
