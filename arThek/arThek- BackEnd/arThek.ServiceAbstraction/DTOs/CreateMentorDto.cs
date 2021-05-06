using arThek.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.ServiceAbstraction.DTOs
{
    public class CreateMentorDto : BaseUser
    {
        public string AboutMe { get; set; }
        public string Experience { get; set; }
        public string LinkdlnUrl { get; set; }
        public string DribbleUrl { get; set; }
        public string BehanceUrl { get; set; }
        public string CarbonMadeUrl { get; set; }
        public IFormFile Resume { get; set; }
        public new IFormFile ProfileImagePath { get; set; }
        public bool IsVolunteer { get; set; }
        public Guid BasicMentorShipId { get; set; }
        public Guid StandardMentorShipId { get; set; }
        public Guid PremiumMentorShipId { get; set; }
        public virtual List<string> Articles { get; set; }
    }
}
