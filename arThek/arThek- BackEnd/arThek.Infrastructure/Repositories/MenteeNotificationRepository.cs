using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;

namespace arThek.Infrastructure.Repositories
{
    public class MenteeNotificationRepository : GenericRepository<MenteeNotification>, IMenteeNotificationRepository
    {
        public MenteeNotificationRepository(arThekContext context) : base(context)
        {
        }
    }
}
