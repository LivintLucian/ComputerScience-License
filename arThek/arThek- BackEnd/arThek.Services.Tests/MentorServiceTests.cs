using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.Services.Filtering;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Services.Tests
{
    public class MentorServiceTests
    {
        private IMapper _mapper;
        private MentorService _mentorService;
        private Mock<IMentorRepository> _mockMentorRepository;
        private ICollection<IMentorConditions> _conditions;

        [SetUp]
        //public void Setup()
        //{
        //    _mockMentorRepository = new Mock<IMentorRepository>();
        //    _mentorService = new MentorService(_mapper,
        //        _mockMentorRepository.Object,
        //        new MentorFilterService(_conditions));
        //}

        [Test]
        public async Task GetAllMentors_Should_Return_All_Mentors_That_Are_Not_Deleted()
        {
            //Arrange
            var mentorList = new List<Mentor>()
            {
                new Mentor { IsDeleted = true },
                new Mentor { IsDeleted = true },
                new Mentor { IsDeleted = false }
            };
            var countMentors = mentorList.Where(x => x.IsDeleted == false).ToList().Count();

            //Act
            var mentorListCount = await _mentorService.GetAllMentors();

            //Assert


        }
    }
}