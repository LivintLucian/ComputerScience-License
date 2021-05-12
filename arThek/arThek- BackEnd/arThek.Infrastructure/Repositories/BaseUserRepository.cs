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
        public async Task<GuestUser> GetValidUserIfExists(string emailAddress, string password)
        {
            var mentorObject = await _arThekContext.Mentors
               .SingleOrDefaultAsync(e => e.Email == emailAddress && e.Password == password);

            var menteeObject = await _arThekContext.Mentees
               .SingleOrDefaultAsync(e => e.Email == emailAddress && e.Password == password);

            if (mentorObject != null || menteeObject != null)
            {
                return new GuestUser
                {
                    Id = mentorObject == null ? menteeObject.Id : mentorObject.Id,
                    Email = mentorObject == null ? menteeObject.Email : mentorObject.Email,
                    Password = mentorObject == null ? menteeObject.Password : mentorObject.Password,
                    Category = mentorObject == null ? menteeObject.Domain : mentorObject.Domain,
                    UserType = mentorObject == null ? menteeObject.UserRole : mentorObject.UserRole
                };
            }
            else
            {
                return null;
            }
        }
    }
}
