using arThek.ServiceAbstraction.DTOs;
using System;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IMenteeService
    {
        Task<MenteeDto> CreateAsync(MenteeDto menteeDto);
        Task<MenteeDto> UpdateAsync(MenteeDto mentorDto, Guid id);
    }
}
