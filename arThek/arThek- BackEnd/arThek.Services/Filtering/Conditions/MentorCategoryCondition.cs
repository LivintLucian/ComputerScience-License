using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.Services.Filtering.Conditions
{
    public class MentorCategoryCondition : IMentorConditions
    {
        private string _mentorCategory;
        public void AddFilterOptions(IFilterMentors options)
        {
            _mentorCategory = options.Domain;
        }

        public bool IsSatisfied(Mentor mentor)
        {
            return _mentorCategory == mentor.Domain;
        }
    }
}
