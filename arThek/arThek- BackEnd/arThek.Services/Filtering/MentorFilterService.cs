using arThek.Entities.Entities;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.InterfaceDTOs;
using System.Collections.Generic;
using System.Linq;

namespace arThek.Services.Filtering
{
    public class MentorFilterService : IMentorFilterService
    {
        private readonly IEnumerable<IMentorConditions> _mentorConditions;

        public MentorFilterService(IEnumerable<IMentorConditions> conditions)
        {
            _mentorConditions = conditions;
        }
       
        public void RegisterFilters(IFilterMentors options)
        {
            _mentorConditions.ToList().ForEach(c => c.AddFilterOptions(options));
        }
        public IEnumerable<Mentor> Execute(IEnumerable<Mentor> mentors)
        {
            return mentors.Where(m => _mentorConditions.All(c => c.IsSatisfied(m))).ToList();
        }
    }
}
