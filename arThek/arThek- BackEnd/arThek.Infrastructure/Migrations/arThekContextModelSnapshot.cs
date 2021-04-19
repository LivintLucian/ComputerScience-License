﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using arThek.Infrastructure.Persistence;

namespace arThek.Infrastructure.Migrations
{
    [DbContext(typeof(arThekContext))]
    partial class arThekContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("arThek.Entities.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImagePath")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UserCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("arThek.Entities.Entities.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MenteeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MentorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("arThek.Entities.Entities.GuestUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MenteeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenteeId");

                    b.HasIndex("MentorId");

                    b.ToTable("BaseUsers");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Mentee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImagePath")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UserCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mentees");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Mentor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AboutMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BasicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BehanceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarbonMadeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DribbleUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVolunteer")
                        .HasColumnType("bit");

                    b.Property<string>("LinkdlnUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PremiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ProfileImagePath")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Resume")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("StandardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UserCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasicId");

                    b.HasIndex("PremiumId");

                    b.HasIndex("StandardId");

                    b.ToTable("Mentors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                            AboutMe = "Logo Designer",
                            Domain = "Designer",
                            Email = "livintlucian@gmail.com",
                            IsDeleted = false,
                            IsVolunteer = false,
                            Password = "q123w321",
                            ProfileImagePath = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            Resume = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            UserCreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "livintlucian",
                            UserRole = 1
                        });
                });

            modelBuilder.Entity("arThek.Entities.Entities.MentorshipPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MentorshipPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MentorshipPackages");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Token", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TokenValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Article", b =>
                {
                    b.HasOne("arThek.Entities.Entities.Mentor", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("arThek.Entities.Entities.GuestUser", b =>
                {
                    b.HasOne("arThek.Entities.Entities.Mentee", "Mentee")
                        .WithMany()
                        .HasForeignKey("MenteeId");

                    b.HasOne("arThek.Entities.Entities.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");

                    b.Navigation("Mentee");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Mentor", b =>
                {
                    b.HasOne("arThek.Entities.Entities.MentorshipPackage", "Basic")
                        .WithMany()
                        .HasForeignKey("BasicId");

                    b.HasOne("arThek.Entities.Entities.MentorshipPackage", "Premium")
                        .WithMany()
                        .HasForeignKey("PremiumId");

                    b.HasOne("arThek.Entities.Entities.MentorshipPackage", "Standard")
                        .WithMany()
                        .HasForeignKey("StandardId");

                    b.Navigation("Basic");

                    b.Navigation("Premium");

                    b.Navigation("Standard");
                });

            modelBuilder.Entity("arThek.Entities.Entities.Mentor", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
