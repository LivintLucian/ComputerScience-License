using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.Entities.Entities
{
    public class User : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
