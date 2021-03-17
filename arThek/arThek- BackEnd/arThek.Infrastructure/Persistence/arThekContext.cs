﻿using arThek.Entities.BaseEntities;
using arThek.Entities.Entities;
using arThek.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace arThek.Infrastructure.Persistence
{
    public class arThekContext : DbContext
    {
        public arThekContext(DbContextOptions<arThekContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Mentee> Mentees { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> BaseUsers { get; set; }
        public DbSet<MentorshipPackage> MentorshipPackages { get; set; }
        public DbSet<MentorArticle> MentorArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MentorArticleConfiguration());
            modelBuilder.ApplyConfiguration(new MentorConfiguration());
        }
    }
}
