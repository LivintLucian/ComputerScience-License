using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.ServiceAbstraction.DTOs
{
    public class MentorAdditionalDataDto
    {
        public string LinkdlnUrl { get; set; }
        public string DribbleUrl { get; set; }
        public string BehanceUrl { get; set; }
        public string CarbonMadeUrl { get; set; }
        public IFormFile Resume { get; set; }
    }
}
