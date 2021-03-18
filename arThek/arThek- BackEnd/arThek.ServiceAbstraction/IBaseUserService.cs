using arThek.ServiceAbstraction.DTOs;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IBaseUserService
    {
        Task<BaseUserDto> LoginAsync(string emailAddress, string password);
    }
}
