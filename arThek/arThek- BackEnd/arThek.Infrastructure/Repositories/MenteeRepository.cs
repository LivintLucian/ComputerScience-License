using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace arThek.Infrastructure.Repositories
{
    public class MenteeRepository : GenericRepository<Mentee>, IMenteeRepository
    {
        public MenteeRepository(arThekContext context) : base(context) { }
    }
}
