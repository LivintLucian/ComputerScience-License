using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;
using System.Collections.Generic;

namespace arThek.ServiceAbstraction
{
    public interface IMentorFilterService
    {
        void RegisterFilters(IFilterMentors options);
        IEnumerable<Mentor> Execute(IEnumerable<Mentor> mentors);
    }
}
