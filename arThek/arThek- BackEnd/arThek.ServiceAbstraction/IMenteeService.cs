using arThek.ServiceAbstraction.DTOs;
using System;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IMenteeService
    {
        Task<MenteeDto> CreateAsync(CreateMenteeDto createMenteeDto);
        Task<MenteeDto> GetByIdAsync(Guid id);
        Task<MenteeDto> UpdateAsync(MenteeDto mentorDto, Guid id);
        MenteeDto GetLastMenteeCreated();
    }
}
