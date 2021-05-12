﻿using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace arThek.Entities.Entities
{
    public class Article : BaseEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public Mentor Author { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
    }
}
