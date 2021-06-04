using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
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
    public class MenteeService : IMenteeService
    {
        private readonly IMapper _mapper;
        private readonly IMenteeRepository _menteeRepository;
        public MenteeService(IMapper mapper, IMenteeRepository menteeRepository)
        {
            _mapper = mapper;
            _menteeRepository = menteeRepository;
        }

        public async Task<MenteeDto> CreateAsync(CreateMenteeDto createMenteeDto)
        {
            var menteeDTO = _mapper.Map<Mentee>(createMenteeDto);
            menteeDTO.ProfileImagePath = GetByteFileArray(createMenteeDto.ProfileImagePath);
            var menteeAddedToDB = await _menteeRepository.CreateAsync(menteeDTO);

            return _mapper.Map<MenteeDto>(menteeAddedToDB);
        }

        public async Task<MenteeDto> UpdateAsync(MenteeDto menteeDto, Guid id)
        {
            var menteeEntity = await _menteeRepository.GetByIdAsync(id);
            if (menteeEntity is null)
                throw new NotFoundException("The mentee wasn't found!");

            _mapper.Map(menteeDto, menteeEntity);
            var menteeUpdated = await _menteeRepository.UpdateAsync(menteeEntity);

            return _mapper.Map<MenteeDto>(menteeUpdated);
        }
        public async Task<MenteeDto> GetByIdAsync(Guid id)
        {
            var mentee = await _menteeRepository.GetByIdAsync(id);

            if (mentee is null)
            {
                throw new NotFoundException("This mentee doesn't exist!");
            }

            return _mapper.Map<MenteeDto>(mentee);
        }

        public MenteeDto GetLastMenteeCreated()
        {
            return _mapper.Map<MenteeDto>(_menteeRepository.GetLastMenteeCreated());
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

        public async Task<IEnumerable<MenteeDto>> GetAllMentees()
        {
            //var result = new List<MenteeDto>();
            var data = (await _menteeRepository.GetAll()).ToList();
            //for(int i = 0; i < data.Count; i++)
            //{
            //    result.Add(_mapper.Map(data[i]));
            //}
            return _mapper.Map<List<MenteeDto>>(data);
        }
    }
}
