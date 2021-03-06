﻿// <auto-generated />
using System;
using Education.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Education.Data.Migrations
{
    [DbContext(typeof(EduContext))]
    [Migration("20210304170304_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Education.Entities.Abstract.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Education.Entities.EvaluatedWork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("EvaluatedWorks");
                });

            modelBuilder.Entity("Education.Entities.EvaluatedWorkAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("WorkId");

                    b.ToTable("EvaluatedWorkAnswers");
                });

            modelBuilder.Entity("Education.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Education.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TutorId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Education.Entities.LessonFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonFiles");
                });

            modelBuilder.Entity("Education.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Education.Entities.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Education.Entities.Score", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MyPropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MyPropertyId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Education.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Education.Entities.Admin", b =>
                {
                    b.HasBaseType("Education.Entities.Abstract.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Education.Entities.Student", b =>
                {
                    b.HasBaseType("Education.Entities.Abstract.User");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Education.Entities.Tutor", b =>
                {
                    b.HasBaseType("Education.Entities.Abstract.User");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WorkExperience")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("Education.Entities.EvaluatedWork", b =>
                {
                    b.HasOne("Education.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");
                });

            modelBuilder.Entity("Education.Entities.EvaluatedWorkAnswer", b =>
                {
                    b.HasOne("Education.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Education.Entities.EvaluatedWork", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("Education.Entities.Lesson", b =>
                {
                    b.HasOne("Education.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Education.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("Education.Entities.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("Education.Entities.LessonFile", b =>
                {
                    b.HasOne("Education.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");
                });

            modelBuilder.Entity("Education.Entities.Notification", b =>
                {
                    b.HasOne("Education.Entities.Abstract.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId");
                });

            modelBuilder.Entity("Education.Entities.Request", b =>
                {
                    b.HasOne("Education.Entities.Abstract.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("Education.Entities.Abstract.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Education.Entities.Score", b =>
                {
                    b.HasOne("Education.Entities.EvaluatedWorkAnswer", "MyProperty")
                        .WithMany()
                        .HasForeignKey("MyPropertyId");

                    b.HasOne("Education.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Education.Entities.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("Education.Entities.Student", b =>
                {
                    b.HasOne("Education.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
