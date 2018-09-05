﻿// <auto-generated />
using System;
using CareerMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CareerMonitoring.Api.Migrations
{
    [DbContext(typeof(CareerMonitoringContext))]
    [Migration("20180905160602_migrationzgzzz")]
    partial class migrationzgzzz
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Abstract.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activated");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.Property<string>("Surname");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.AccountActivation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("ActivatedAt");

                    b.Property<Guid>("ActivationKey");

                    b.Property<bool>("Active");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountActivation");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.AccountRestoringPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<bool>("Restored");

                    b.Property<DateTime>("RestoredAt");

                    b.Property<Guid>("Token");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountRestoringPasswords");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfReceived");

                    b.Property<int?>("GraduateId");

                    b.Property<int?>("StudentId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GraduateId");

                    b.HasIndex("StudentId");

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GraduateId");

                    b.Property<string>("Name");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("GraduateId");

                    b.HasIndex("StudentId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Course");

                    b.Property<bool>("Graduate");

                    b.Property<int?>("GraduateId");

                    b.Property<string>("Specialization");

                    b.Property<int?>("StudentId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("GraduateId");

                    b.HasIndex("StudentId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("From");

                    b.Property<int?>("GraduateId");

                    b.Property<string>("Location");

                    b.Property<string>("Position");

                    b.Property<int?>("StudentId");

                    b.Property<DateTime>("To");

                    b.HasKey("Id");

                    b.HasIndex("GraduateId");

                    b.HasIndex("StudentId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<int?>("EmployerId");

                    b.Property<string>("JobType");

                    b.Property<string>("Location");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Position");

                    b.Property<string>("WebsiteAddress");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("JobOffer");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GraduateId");

                    b.Property<string>("Name");

                    b.Property<string>("Proficiency");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("GraduateId");

                    b.HasIndex("StudentId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GraduateId");

                    b.Property<string>("Name");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("GraduateId");

                    b.HasIndex("StudentId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.LinearScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("MarkedValue");

                    b.Property<string>("MaxLabel");

                    b.Property<int>("MaxValue");

                    b.Property<string>("MinLabel");

                    b.Property<int>("MinValue");

                    b.Property<int?>("SurveyId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("LinearScales");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.MultipleChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("MarkedAnswersNames");

                    b.Property<int?>("SurveyId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("MultipleChoices");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.SingleChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("MarkedAnswerName");

                    b.Property<int?>("SurveyId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SingleChoices");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<bool>("Answered");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.CareerOffice", b =>
                {
                    b.HasBaseType("CareerMonitoring.Core.Domains.Abstract.Account");


                    b.ToTable("CareerOffice");

                    b.HasDiscriminator().HasValue("CareerOffice");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Employer", b =>
                {
                    b.HasBaseType("CareerMonitoring.Core.Domains.Abstract.Account");

                    b.Property<string>("CompanyDescription");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Location");

                    b.ToTable("Employer");

                    b.HasDiscriminator().HasValue("Employer");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Graduate", b =>
                {
                    b.HasBaseType("CareerMonitoring.Core.Domains.Abstract.Account");

                    b.Property<string>("ProfileLink");

                    b.ToTable("Graduate");

                    b.HasDiscriminator().HasValue("Graduate");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Student", b =>
                {
                    b.HasBaseType("CareerMonitoring.Core.Domains.Abstract.Account");

                    b.Property<string>("IndexNumber");

                    b.Property<string>("ProfileLink")
                        .HasColumnName("Student_ProfileLink");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.AccountActivation", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithOne("AccountActivation")
                        .HasForeignKey("CareerMonitoring.Core.Domains.AccountActivation", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.AccountRestoringPassword", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithOne("AccountRestoringPassword")
                        .HasForeignKey("CareerMonitoring.Core.Domains.AccountRestoringPassword", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Certificate", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Graduate")
                        .WithMany("Certificates")
                        .HasForeignKey("GraduateId");

                    b.HasOne("CareerMonitoring.Core.Domains.Student")
                        .WithMany("Certificates")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Course", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Graduate")
                        .WithMany("Courses")
                        .HasForeignKey("GraduateId");

                    b.HasOne("CareerMonitoring.Core.Domains.Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Education", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Graduate")
                        .WithMany("Educations")
                        .HasForeignKey("GraduateId");

                    b.HasOne("CareerMonitoring.Core.Domains.Student")
                        .WithMany("Educations")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Experience", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Graduate")
                        .WithMany("Experiences")
                        .HasForeignKey("GraduateId");

                    b.HasOne("CareerMonitoring.Core.Domains.Student")
                        .WithMany("Experiences")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.JobOffer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Employer")
                        .WithMany("JobOffers")
                        .HasForeignKey("EmployerId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Language", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Graduate")
                        .WithMany("Languages")
                        .HasForeignKey("GraduateId");

                    b.HasOne("CareerMonitoring.Core.Domains.Student")
                        .WithMany("Languages")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Skill", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Graduate")
                        .WithMany("Skills")
                        .HasForeignKey("GraduateId");

                    b.HasOne("CareerMonitoring.Core.Domains.Student")
                        .WithMany("Skills")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.LinearScale", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.Survey", "Survey")
                        .WithMany("LinearScales")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.MultipleChoice", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.Survey", "Survey")
                        .WithMany("MultipleChoices")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.SingleChoice", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.Survey", "Survey")
                        .WithMany("SingleChoices")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}