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
    [Migration("20180917125633_int")]
    partial class @int
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

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("DateOfReceived");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Course");

                    b.Property<bool>("Graduated");

                    b.Property<string>("NameOfUniversity");

                    b.Property<string>("Specialization");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("From");

                    b.Property<bool>("IsCurrentJob");

                    b.Property<string>("Location");

                    b.Property<string>("Position");

                    b.Property<DateTime>("To");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Experiences");
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

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Name");

                    b.Property<string>("Proficiency");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.ProfileLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Content");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("ProfileLinks");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.ChoiceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldDataId");

                    b.Property<int>("OptionPosition");

                    b.Property<bool>("Value");

                    b.Property<string>("ViewValue");

                    b.HasKey("Id");

                    b.HasIndex("FieldDataId");

                    b.ToTable("ChoiceOptions");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.FieldData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Input");

                    b.Property<string>("MaxLabel");

                    b.Property<int>("MaxValue");

                    b.Property<string>("MinLabel");

                    b.Property<int>("MinValue");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("FieldData");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("QuestionPosition");

                    b.Property<string>("Select");

                    b.Property<int>("SurveyId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.Row", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldDataId");

                    b.Property<string>("Input");

                    b.Property<int>("RowPosition");

                    b.HasKey("Id");

                    b.HasIndex("FieldDataId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answered");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.ChoiceOptionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldDataAnswerId");

                    b.Property<int>("OptionPosition");

                    b.Property<bool>("Value");

                    b.Property<string>("ViewValue");

                    b.HasKey("Id");

                    b.HasIndex("FieldDataAnswerId");

                    b.ToTable("ChoiceOptionsAnswers");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.FieldDataAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Input");

                    b.Property<string>("MaxLabel");

                    b.Property<string>("MinLabel");

                    b.Property<int>("QuestionAnswerId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionAnswerId");

                    b.ToTable("FieldDataAnswers");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("QuestionPosition");

                    b.Property<string>("Select");

                    b.Property<int>("SurveyAnswerId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyAnswerId");

                    b.ToTable("QuestionsAnswers");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.RowAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldDataAnswerId");

                    b.Property<string>("Input");

                    b.Property<int>("RowPosition");

                    b.HasKey("Id");

                    b.HasIndex("FieldDataAnswerId");

                    b.ToTable("RowAnswers");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.RowChoiceOptionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionPosition");

                    b.Property<int>("RowAnswerId");

                    b.Property<bool>("Value");

                    b.Property<string>("ViewValue");

                    b.HasKey("Id");

                    b.HasIndex("RowAnswerId");

                    b.ToTable("RowChoiceOptionsAnswers");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.SurveyAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answered");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("SurveyId");

                    b.Property<string>("SurveyTitle");

                    b.HasKey("Id");

                    b.ToTable("SurveyAnswers");
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


                    b.ToTable("Graduate");

                    b.HasDiscriminator().HasValue("Graduate");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Student", b =>
                {
                    b.HasBaseType("CareerMonitoring.Core.Domains.Abstract.Account");

                    b.Property<string>("IndexNumber");

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
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithMany("Certificates")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Course", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithMany("Courses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Education", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithMany("Educations")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Experience", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithMany("Experiences")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.JobOffer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Employer")
                        .WithMany("JobOffers")
                        .HasForeignKey("EmployerId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Language", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithMany("Languages")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.ProfileLink", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account", "Account")
                        .WithOne("ProfileLink")
                        .HasForeignKey("CareerMonitoring.Core.Domains.ProfileLink", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Skill", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Abstract.Account")
                        .WithMany("Skills")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.ChoiceOption", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.FieldData", "FieldData")
                        .WithMany("ChoiceOptions")
                        .HasForeignKey("FieldDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.FieldData", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.Question", "Question")
                        .WithMany("FieldData")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.Question", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.Surveys.Row", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.Surveys.FieldData", "FieldData")
                        .WithMany("Rows")
                        .HasForeignKey("FieldDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.ChoiceOptionAnswer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.SurveysAnswers.FieldDataAnswer", "FieldDataAnswer")
                        .WithMany("ChoiceOptionAnswers")
                        .HasForeignKey("FieldDataAnswerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.FieldDataAnswer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.SurveysAnswers.QuestionAnswer", "QuestionAnswer")
                        .WithMany("FieldDataAnswers")
                        .HasForeignKey("QuestionAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.QuestionAnswer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.SurveysAnswers.SurveyAnswer", "SurveyAnswer")
                        .WithMany("QuestionsAnswers")
                        .HasForeignKey("SurveyAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.RowAnswer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.SurveysAnswers.FieldDataAnswer", "FieldDataAnswer")
                        .WithMany("RowsAnswers")
                        .HasForeignKey("FieldDataAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerMonitoring.Core.Domains.SurveysAnswers.RowChoiceOptionAnswer", b =>
                {
                    b.HasOne("CareerMonitoring.Core.Domains.SurveysAnswers.RowAnswer", "RowAnswer")
                        .WithMany("RowChoiceOptionAnswers")
                        .HasForeignKey("RowAnswerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
