using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.ServiceAbstraction.InterfaceDTOs
{
    public interface IFilterMentors
    {
        string Name { get; set; }
        string Category { get; set; }
        bool IsVolunteer { get; set; }
    }
}
