using Amazon.SimpleNotificationService.Model;
using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class BaseUserService : IBaseUserService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IBaseUserRepository _baseUserRepository;

        public BaseUserService(IMapper mapper,
            IConfiguration configuration,
            IBaseUserRepository baseUserRepository
            )
        {
            _mapper = mapper;
            _configuration = configuration;
            _baseUserRepository = baseUserRepository;
        }
        public async Task<BaseUserDto> LoginAsync(string emailAddress, string password)
        {
            var baseUser = await _baseUserRepository.GetValidUserIfExists(emailAddress, password);

            if(baseUser == null)
            {
                throw new NotFoundException($"User with email {emailAddress} wasn't found");
            }

            var token = CreateToken(baseUser);
            var baseUserDto = _mapper.Map<BaseUserDto>(baseUser);
            baseUserDto.Token = token;

            return baseUserDto;
        }

        private string CreateToken(GuestUser baseUser)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, baseUser.Id.ToString()),
                new Claim(ClaimTypes.Email, baseUser.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSetting:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
