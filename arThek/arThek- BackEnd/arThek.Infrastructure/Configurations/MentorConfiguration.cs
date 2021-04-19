using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

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
                    UserName="livintlucian",
                    Password = "q123w321",
                    AboutMe = "Logo Designer",
                    Domain = "Designer",
                    Email = "livintlucian@gmail.com",
                    IsVolunteer = false,
                    Articles = new List<Article>(),
                    ProfileImagePath = new byte[15],
                    Resume = new byte[15],
                    UserRole = UserRole.Mentor,
                    Basic = null,
                    Premium = null,
                    Standard = null,
                });
        }
    }
}
