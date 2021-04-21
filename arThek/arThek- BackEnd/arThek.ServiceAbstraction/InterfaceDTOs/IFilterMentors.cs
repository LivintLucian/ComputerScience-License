using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.ServiceAbstraction.InterfaceDTOs
{
    public interface IFilterMentors
    {
        string UserName { get; set; }
        string Domain { get; set; }
        bool IsVolunteer { get; set; }
    }
}
