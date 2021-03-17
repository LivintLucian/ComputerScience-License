using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync();
        Task<Guid?> ValidateTokenAsync(string token);
    }
}
