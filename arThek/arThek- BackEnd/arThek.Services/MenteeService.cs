using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class MenteeService : IMenteeService
    {
        private readonly IMapper _mapper;
        private readonly IMenteeRepository _menteeRepository;
        public MenteeService(IMapper mapper, IMenteeRepository menteeRepository)
        {
            _mapper = mapper;
            _menteeRepository = menteeRepository;
        }

        public async Task<MenteeDto> CreateAsync(MenteeDto menteeDto)
        {
            var menteeDTO = _mapper.Map<Mentee>(menteeDto);
            var menteeAddedToDB = await _menteeRepository.CreateAsync(menteeDTO);

            return _mapper.Map<MenteeDto>(menteeAddedToDB);
        }

        public async Task<MenteeDto> UpdateAsync(MenteeDto menteeDto, Guid id)
        {
            var mentorEntity = await _menteeRepository.GetByIdAsync(id);
            if (mentorEntity is null)
                throw new NotFoundException("The mentee wasn't found!");

            _mapper.Map(menteeDto, mentorEntity);
            var menteeUpdated = await _menteeRepository.UpdateAsync(mentorEntity);

            return _mapper.Map<MenteeDto>(menteeUpdated);
        }
    }
}
