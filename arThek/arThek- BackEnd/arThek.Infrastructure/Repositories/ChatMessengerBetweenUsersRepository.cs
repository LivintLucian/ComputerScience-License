using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Infrastructure.Repositories
{
    public class ChatMessengerBetweenUsersRepository : GenericRepository<ChatMessengerBetweenUsers>, IChatMessengerBetweenUsersRepository
    {
        public ChatMessengerBetweenUsersRepository(arThekContext context) : base(context) {}
    }
}
