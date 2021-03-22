using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IMentorService
    {
        Task<MentorDto> CreateAsync(MentorDto mentorDto);
        Task<MentorDto> GetByIdAsync(Guid id);
        Task<IEnumerable<MentorDto>> GetAllMentors();
        Task<MentorDto> UpdateAsync(MentorDto mentorDto, Guid id);
        Task<MentorDto> DeleteAsync(Guid id);
        Task<List<ViewMentorDto>> GetFilteredTrainings(MentorParametersDto trainingParametersDto);
        Task<MentorDto> UpdateMentorResume(MentorDto mentorDto, Guid id);
    }
}
