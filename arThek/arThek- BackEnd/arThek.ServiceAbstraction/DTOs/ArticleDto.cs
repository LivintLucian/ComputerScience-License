﻿using arThek.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.ServiceAbstraction.DTOs
{
    public class ArticleDto : BaseEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int Rating { get; set; }
    }
}
