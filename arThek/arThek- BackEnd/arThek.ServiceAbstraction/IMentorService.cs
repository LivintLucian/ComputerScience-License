using arThek.Entities.Entities;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IMentorService
    {
        Task<MentorDto> CreateAsync(CreateMentorDto mentorDto);
        Task<MentorDto> GetByIdAsync(Guid id);
        Task<MentorProfileUpdateDto> GetLastMentorAsync();
        Task<IEnumerable<MentorDto>> GetAllMentors();
        Task<MentorDto> UpdateAsync(MentorDto mentorDto, Guid id);
        Task<MentorDto> UpdateLastMentorAdded(Boolean isVolunteer);
        Task<MentorProfileUpdateDto> UpdateMentorProfile(MentorProfileUpdateDto mentorDto);
        Task<MentorDto> DeleteAsync(Guid id);
        Task<List<ViewMentorDto>> GetFilteredTrainings(MentorParametersDto mentorParametersDto);
        Task<MentorAdditionalDataDto> UpdateMentorResume(MentorAdditionalDataDto mentorDto);
    }
}
