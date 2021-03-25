using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;

namespace arThek.Infrastructure.Repositories
{
    public class ChatMessageRepository : GenericRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(arThekContext context) : base(context) { }
    }
}
