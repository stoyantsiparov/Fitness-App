﻿// <auto-generated />
using System;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125155334_ChangedFitnessEventSeededInfo")]
    partial class ChangedFitnessEventSeededInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessApp.Data.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Description of the fitness class");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("Duration of the fitness class in minutes");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image URL of the fitness class");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasComment("Instructor of the fitness class");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Name of the fitness class");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of the fitness class");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A calm and peaceful yoga session to start your day.",
                            Duration = 60,
                            ImageUrl = "https://yogajala.com/wp-content/uploads/8-Benefits-Of-Morning-Yoga.jpg",
                            InstructorId = 1,
                            Name = "Morning Yoga",
                            Schedule = new DateTime(2024, 12, 5, 7, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "An intense, high-energy interval training session.",
                            Duration = 45,
                            ImageUrl = "https://i.ytimg.com/vi/66_hHeSUrzU/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLB88ucCUVHp_EFpv6T47y7oJRpRsQ",
                            InstructorId = 2,
                            Name = "HIIT Challenge",
                            Schedule = new DateTime(2024, 12, 5, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "A fun and energetic Zumba dance class for all levels.",
                            Duration = 60,
                            ImageUrl = "https://i.ytimg.com/vi/N3wBXogMYfM/hq720.jpg?sqp=-oaymwE7CK4FEIIDSFryq4qpAy0IARUAAAAAGAElAADIQj0AgKJD8AEB-AH-CYAC0AWKAgwIABABGGUgUihUMA8=&rs=AOn4CLD9yvCPKa7mHvL_lLUQr-TvnlNYRw",
                            InstructorId = 3,
                            Name = "Zumba Party",
                            Schedule = new DateTime(2024, 12, 6, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FitnessApp.Data.Models.ClassRegistration", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MemberId1")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "MemberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("MemberId1");

                    b.ToTable("ClassesRegistrations");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.EventRegistration", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MemberId1")
                        .HasColumnType("int");

                    b.HasKey("EventId", "MemberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("MemberId1");

                    b.ToTable("EventRegistrations");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.FitnessEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Description of the fitness event");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("End date of the fitness event");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image URL of the fitness class");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Location of the fitness event");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Start date of the fitness event");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Title of the fitness event");

                    b.HasKey("Id");

                    b.ToTable("FitnessEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Join us for a thrilling 10K spring marathon through the city streets.",
                            EndDate = new DateTime(2025, 4, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://example.com/spring-marathon.jpg",
                            Location = "Downtown City Center",
                            StartDate = new DateTime(2025, 4, 12, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spring City Marathon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A challenging hike to the top of the mountain with stunning views.",
                            EndDate = new DateTime(2025, 7, 15, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://example.com/mountain-hike.jpg",
                            Location = "Rocky Mountain Trail",
                            StartDate = new DateTime(2025, 7, 15, 6, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mountain Peak Hike"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A scenic walk around the beautiful autumn lake. Perfect for relaxation and exercise.",
                            EndDate = new DateTime(2025, 10, 8, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://example.com/autumn-lake-walk.jpg",
                            Location = "Autumn Lake Park",
                            StartDate = new DateTime(2025, 10, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Autumn Lake Walk"
                        });
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Biography of the fitness instructor");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("First name of the fitness instructor");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image URL of the fitness instructor");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Last name of the fitness instructor");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Specialization of the fitness instructor");

                    b.HasKey("Id");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Natalie is a certified yoga instructor with over 10 years of experience. She is passionate about helping others achieve their fitness goals and improve their overall well-being.",
                            FirstName = "Natalie",
                            ImageUrl = "https://horizonweekly.ca/wp-content/uploads/2021/01/Nat-2.jpg",
                            LastName = "Asatryan",
                            Specialization = "Yoga"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Warren is a certified personal trainer and fitness coach. He specializes in high-intensity interval training (HIIT) and enjoys helping clients push their limits and reach their full potential.",
                            FirstName = "Warren",
                            ImageUrl = "https://images.squarespace-cdn.com/content/v1/651489d366d19e59b7bbf9cf/a68428a6-992f-45a4-adfc-1b5a75e5cfda/Warren_square500.jpg",
                            LastName = "Scott",
                            Specialization = "HIIT"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Emily is a certified Zumba instructor with a background in dance and fitness. She loves creating a fun and inclusive environment where everyone can enjoy the benefits of Zumba.",
                            FirstName = "Emily",
                            ImageUrl = "https://d29za44huniau5.cloudfront.net/uploads/2023/11/first-class-mobile.png",
                            LastName = "Johnson",
                            Specialization = "Zumba"
                        });
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Email of the member");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("First name of the member");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date whn the member joined the gym");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Last name of the member");

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("int")
                        .HasComment("Membership type of the member");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Phone number of the member");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("Duration of the membership type in days");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Membership type");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the membership type");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.SpaProcedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDateTime")
                        .HasColumnType("datetime2")
                        .HasComment("Appointment date and time for the spa service");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Description of the spa procedure");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("Duration of the spa procedure in minutes");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image URL of the spa procedure");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Spa type");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the spa procedure");

                    b.HasKey("Id");

                    b.ToTable("SpaProcedures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A soothing massage to relieve tension and stress.",
                            Duration = 60,
                            ImageUrl = "https://www.dshieldsusa.com/wp-content/uploads/2021/05/relaxing-massage-slide.jpg",
                            Name = "Relaxing Massage",
                            Price = 50.00m
                        },
                        new
                        {
                            Id = 2,
                            AppointmentDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A rejuvenating facial to nourish and hydrate your skin.",
                            Duration = 45,
                            ImageUrl = "https://spamd.net/wp-content/uploads/2022/03/medications-facial-treatments.jpg",
                            Name = "Facial Treatment",
                            Price = 40.00m
                        },
                        new
                        {
                            Id = 3,
                            AppointmentDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A session using essential oils to promote relaxation and well-being.",
                            Duration = 30,
                            ImageUrl = "https://elementsmassage.com/files/shared/AZ%20-%20Elements%20Massage%205-1864269.jpg",
                            Name = "Aromatherapy Session",
                            Price = 30.00m
                        });
                });

            modelBuilder.Entity("FitnessApp.Data.Models.SpaRegistration", b =>
                {
                    b.Property<int>("SpaProcedureId")
                        .HasColumnType("int");

                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MemberId1")
                        .HasColumnType("int");

                    b.HasKey("SpaProcedureId", "MemberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("MemberId1");

                    b.ToTable("SpaRegistrations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Class", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.Instructor", "Instructor")
                        .WithMany("Classes")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.ClassRegistration", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.Class", "Class")
                        .WithMany("ClassesRegistrations")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Data.Models.Member", null)
                        .WithMany("ClassRegistrations")
                        .HasForeignKey("MemberId1");

                    b.Navigation("Class");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.EventRegistration", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.FitnessEvent", "FitnessEvent")
                        .WithMany("EventsRegistrations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Data.Models.Member", null)
                        .WithMany("EventRegistrations")
                        .HasForeignKey("MemberId1");

                    b.Navigation("FitnessEvent");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Member", b =>
                {
                    b.HasOne("FitnessApp.Data.Models.MembershipType", "MembershipType")
                        .WithMany("Members")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.SpaRegistration", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Data.Models.Member", null)
                        .WithMany("SpaRegistrations")
                        .HasForeignKey("MemberId1");

                    b.HasOne("FitnessApp.Data.Models.SpaProcedure", "SpaProcedure")
                        .WithMany("SpaRegistrations")
                        .HasForeignKey("SpaProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("SpaProcedure");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Class", b =>
                {
                    b.Navigation("ClassesRegistrations");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.FitnessEvent", b =>
                {
                    b.Navigation("EventsRegistrations");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Instructor", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.Member", b =>
                {
                    b.Navigation("ClassRegistrations");

                    b.Navigation("EventRegistrations");

                    b.Navigation("SpaRegistrations");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.MembershipType", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("FitnessApp.Data.Models.SpaProcedure", b =>
                {
                    b.Navigation("SpaRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
