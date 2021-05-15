using System;

namespace arThek.API.Persistence
{
    public class Message
    {
        public string User { get; set; }
        public string MsgText { get; set; }
        public string Category { get; set; }
        public string UserType { get; set; }
        public string MessageDate { get; set; }
    }
}
