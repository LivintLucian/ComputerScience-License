using Microsoft.AspNetCore.Http;
using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class MentorProfileUpdateDto
    {
        public string UserName { get; set; }
        public string Domain { get; set; }
        public string AboutMe { get; set; }
        public string DribbleUrl { get; set; }
        public string BehanceUrl { get; set; }
        public string CarbonMadeUrl { get; set; }
        public IFormFile ProfileImagePath { get; set; }
        public Guid BasicMentorShipId { get; set; }
        public Guid StandardMentorShipId { get; set; }
        public Guid PremiumMentorShipId { get; set; }
    }
}
