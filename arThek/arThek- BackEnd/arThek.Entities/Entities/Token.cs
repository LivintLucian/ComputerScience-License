using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class Token : BaseEntity
    {
        public string TokenValue { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
