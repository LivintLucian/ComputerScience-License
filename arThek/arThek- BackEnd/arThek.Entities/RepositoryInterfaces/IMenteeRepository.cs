using arThek.Entities.Entities;
using System;

namespace arThek.Entities.RepositoryInterfaces
{
    public interface IMenteeRepository : IGenericRepository<Mentee> 
    {
        Mentee GetLastMenteeCreated();
    }
}
