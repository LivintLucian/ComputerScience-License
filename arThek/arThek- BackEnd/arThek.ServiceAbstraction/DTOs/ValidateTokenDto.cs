﻿using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.ServiceAbstraction.DTOs
{
    class ValidateTokenDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
