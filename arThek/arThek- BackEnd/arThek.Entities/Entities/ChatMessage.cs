using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class ChatMessage : BaseEntity
    {
        public string User { get; set; }
        public string MsgText { get; set; }
        public string Category { get; set; }
        public string UserType { get; set; }
        public string MessageDate { get; set; }
    }
}
