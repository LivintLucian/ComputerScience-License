﻿using arThek.Entities.Entities;
using System.Threading.Tasks;

namespace arThek.Entities.RepositoryInterfaces
{
    public interface IBaseUserRepository
    {
        Task<GuestUser> GetValidUserIfExists(string emailAddress, string password);
    }
}
