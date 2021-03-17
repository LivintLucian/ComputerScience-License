﻿using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace arThek.ServiceAbstraction.DTOs
{
    public class MentorDto : BaseUser
    {
        public string AboutMe { get; set; }
        public string Experience { get; set; }
        public byte[] Resume { get; set; }
        public bool IsVolunteer { get; set; }
        public Guid BasicMentorShipId { get; set; }
        public Guid StandardMentorShipId { get; set; }
        public Guid PremiumMentorShipId { get; set; }
        public virtual List<string> Articles { get; set; }
    }
}
