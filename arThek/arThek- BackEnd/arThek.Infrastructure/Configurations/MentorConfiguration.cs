using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.Infrastructure.Configurations
{
    public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
            builder.ToTable("Mentors");

            builder.HasData(
                new Mentor()
                {
                    Id = new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                    FirstName = "Lucian",
                    LastName = "Livint",
                    Password = "q123w321",
                    PhoneNumber = "+40 748 032 932",
                    AboutMe = "Logo Designer",
                    Category = "Designer",
                    Experience = "I've on the market since 2007",
                    Email = "livintlucian@gmail.com",
                    IsVolunteer = false,
                    MentorArticles = new List<MentorArticle>(),
                    ProfileImage = new byte[15],
                    Resume = new byte[15],
                    UserRole = UserRole.Mentor,
                    Basic = null,
                    Premium = null,
                    Standard = null,
                    ChatMessageId = new Guid("c070b2a0-2b90-40c1-80ea-722294ceccf3"),
                });
        }
    }
}
