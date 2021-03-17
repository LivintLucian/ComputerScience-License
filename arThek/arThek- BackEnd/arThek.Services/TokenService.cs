using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfiguration _configuration;

        public TokenService(ITokenRepository tokenRepository, IConfiguration configuration)
        {
            _tokenRepository = tokenRepository;
            _configuration = configuration;
        }
        public async Task<string> GenerateTokenAsync()
        {
            var token = new Token()
            {
                TokenValue = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddHours(_configuration.GetValue<double>("TokenExpireHours"))
            };

            var tokenFromDB = await _tokenRepository.CreateAsync(token);

            return tokenFromDB.TokenValue;
        }

        public async Task<Guid?> ValidateTokenAsync(string token)
        {
            var tokenFromDB = await _tokenRepository.FindByTokenAsync(token);

            if (tokenFromDB == null)
                return null;

            if(DateTime.Now > tokenFromDB.ExpirationDate)
            {
                await _tokenRepository.DeleteAsync(tokenFromDB);
                return null;
            }

            return tokenFromDB.Id;
        }
    }
}
