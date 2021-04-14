using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Repositories;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly IMentorRepository _mentorRepository;
        private readonly IMentorFilterService _mentorFilterService;

        public MentorService(IMapper mapper,
            IMentorRepository mentorRepository,
            IMentorFilterService mentorFilterService)
        {
            _mapper = mapper;
            _mentorRepository = mentorRepository;
            _mentorFilterService = mentorFilterService;
        }

        #region CRUD

        public async Task<MentorDto> CreateAsync(MentorDto mentorDto)
        {
            var mentorDTO = _mapper.Map<Mentor>(mentorDto);
            mentorDTO.UserRole = Entities.BaseEntities.UserRole.Mentor;
            var mentorAddedToDB = await _mentorRepository.CreateAsync(mentorDTO);

            return _mapper.Map<MentorDto>(mentorAddedToDB);
        }
        public async Task<MentorDto> GetByIdAsync(Guid id)
        {
            var mentor = await _mentorRepository.GetByIdAsync(id);

            if (mentor is null)
            {
                throw new NotFoundException("This mentor doesn't exist!");
            }

            return _mapper.Map<MentorDto>(mentor);
        }
        public async Task<IEnumerable<MentorDto>> GetAllMentors()
        {
            var mentors = (await _mentorRepository.GetAll()).ToList();
            var mentorList = _mapper.Map<IEnumerable<MentorDto>>(mentors);

            return mentorList;
        }
        public async Task<MentorDto> UpdateAsync(MentorDto mentorDto, Guid id)
        {
            var mentorEntity = await _mentorRepository.GetByIdAsync(id);
            if (mentorEntity is null)
                throw new NotFoundException("The mentor wasn't found!");

            mentorEntity.UserRole = Entities.BaseEntities.UserRole.Mentor;
            _mapper.Map(mentorDto, mentorEntity);
            var mentorUpdated = await _mentorRepository.UpdateAsync(mentorEntity);

            return _mapper.Map<MentorDto>(mentorUpdated);
        }
        public async Task<MentorDto> UpdateLastMentorAdded(Boolean isVolunteer)
        {
            var mentorEntity = await _mentorRepository.GetLastMentorAdded();
            if (mentorEntity is null)
                throw new NotFoundException("The mentor wasn't found!");

            mentorEntity.IsVolunteer = isVolunteer;
            var mentorUpdated = await _mentorRepository.UpdateAsync(mentorEntity);

            return _mapper.Map<MentorDto>(mentorUpdated);
        }
        public async Task<MentorDto> DeleteAsync(Guid id)
        {
            var mentorEntity = await _mentorRepository.GetByIdAsync(id);
            if (mentorEntity == null || mentorEntity.IsDeleted == true)
                throw new NotFoundException("The Mentor not found");

            mentorEntity.IsDeleted = true;
            var updatedTraining = await _mentorRepository.UpdateAsync(mentorEntity);

            return _mapper.Map<MentorDto>(updatedTraining);
        }

        #endregion
        public async Task<List<ViewMentorDto>> GetFilteredTrainings(MentorParametersDto mentorParametersDto)
        {
            var mentors = await _mentorRepository.GetAll();
            var filterOptions = mentorParametersDto.FilterMentorsDto ?? new FilterMentorsDto();

            _mentorFilterService.RegisterFilters(filterOptions);

            var filteredMentors = _mentorFilterService
                .Execute(mentors)
                .ToList();

            return _mapper.Map<List<ViewMentorDto>>(filteredMentors);
        }
        public async Task<MentorAdditionalDataDto> UpdateMentorResume(MentorAdditionalDataDto mentorDto)
        {

            var mentorEntity = await _mentorRepository.GetLastMentorAdded();
            if (mentorEntity is null)
                throw new NotFoundException("The mentor wasn't found!");

            mentorEntity.Resume = GetByteFileArray(mentorDto.Resume);
            _mapper.Map(mentorDto, mentorEntity);

            var mentorUpdated = await _mentorRepository.UpdateAsync(mentorEntity);

            return _mapper.Map<MentorAdditionalDataDto>(mentorUpdated);
        }
        private byte[] GetByteFileArray(IFormFile byteFile)
        {
            byte[] array = null;
            if (byteFile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byteFile.CopyTo(ms);
                    array = ms.ToArray();
                }
            }

            return array;
        }
    }
}
