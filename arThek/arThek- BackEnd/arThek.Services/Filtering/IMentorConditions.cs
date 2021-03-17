using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.Services.Filtering
{
    public interface IMentorConditions
    {
        void AddFilterOptions(IFilterMentors options);
        bool IsSatisfied(Mentor mentor);
    }
}
