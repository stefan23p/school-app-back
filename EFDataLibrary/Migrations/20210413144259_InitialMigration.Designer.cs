﻿// <auto-generated />
using System;
using EFDataLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDataLibrary.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210413144259_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDataLibrary.Models.Exam", b =>
                {
                    b.Property<int>("ExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProfessorID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<string>("criteria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("numberOfTasks")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamID");

                    b.HasIndex("ProfessorID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Exam");

                    b.HasData(
                        new
                        {
                            ExamID = 1,
                            ProfessorID = 1,
                            SubjectID = 1,
                            criteria = "hard",
                            date = "02-05-2021",
                            numberOfTasks = 5,
                            type = "Exam"
                        },
                        new
                        {
                            ExamID = 2,
                            ProfessorID = 1,
                            SubjectID = 2,
                            criteria = "medium",
                            date = "02-05-2021",
                            numberOfTasks = 3,
                            type = "Coloquium"
                        },
                        new
                        {
                            ExamID = 3,
                            ProfessorID = 2,
                            SubjectID = 4,
                            criteria = "hard",
                            date = "02-05-2021",
                            numberOfTasks = 4,
                            type = "Exam"
                        },
                        new
                        {
                            ExamID = 4,
                            ProfessorID = 3,
                            SubjectID = 5,
                            criteria = "easy",
                            date = "02-05-2021",
                            numberOfTasks = 5,
                            type = "Exam"
                        },
                        new
                        {
                            ExamID = 5,
                            ProfessorID = 4,
                            SubjectID = 2,
                            criteria = "easy",
                            date = "02-05-2021",
                            numberOfTasks = 5,
                            type = "Coloquium"
                        });
                });

            modelBuilder.Entity("EFDataLibrary.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("ExamsId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ProfessorID");

                    b.ToTable("Professor");

                    b.HasData(
                        new
                        {
                            ProfessorID = 1,
                            Address = "Makedonska,Beograd",
                            ExamsId = 0,
                            LastName = "Markovic",
                            Name = "Marko"
                        },
                        new
                        {
                            ProfessorID = 2,
                            Address = "Goce Delceva,Beograd",
                            ExamsId = 0,
                            LastName = "Popovic",
                            Name = "Milos"
                        },
                        new
                        {
                            ProfessorID = 3,
                            Address = "Svetosavska,Beograd",
                            ExamsId = 0,
                            LastName = "Milosevic",
                            Name = "Milica"
                        });
                });

            modelBuilder.Entity("EFDataLibrary.Models.ProfessorSubject", b =>
                {
                    b.Property<int>("Professor_Id")
                        .HasColumnType("int");

                    b.Property<int>("Subject_Id")
                        .HasColumnType("int");

                    b.HasKey("Professor_Id", "Subject_Id");

                    b.HasIndex("Subject_Id");

                    b.ToTable("ProfessorSubject");

                    b.HasData(
                        new
                        {
                            Professor_Id = 1,
                            Subject_Id = 1
                        },
                        new
                        {
                            Professor_Id = 1,
                            Subject_Id = 2
                        },
                        new
                        {
                            Professor_Id = 2,
                            Subject_Id = 2
                        },
                        new
                        {
                            Professor_Id = 3,
                            Subject_Id = 3
                        },
                        new
                        {
                            Professor_Id = 1,
                            Subject_Id = 4
                        });
                });

          

            modelBuilder.Entity("EFDataLibrary.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("SubjectID");

                    b.ToTable("Subject");

                    b.HasData(
                        new
                        {
                            SubjectID = 1,
                            Name = "Mathematics",
                            Semester = 1
                        },
                        new
                        {
                            SubjectID = 2,
                            Name = "Operative systems",
                            Semester = 1
                        },
                        new
                        {
                            SubjectID = 3,
                            Name = "Economics",
                            Semester = 2
                        },
                        new
                        {
                            SubjectID = 4,
                            Name = "Marketing",
                            Semester = 2
                        });
                });

            modelBuilder.Entity("EFDataLibrary.Models.Exam", b =>
                {
                    b.HasOne("EFDataLibrary.Models.Professor", "Professor")
                        .WithMany("Exams")
                        .HasForeignKey("ProfessorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataLibrary.Models.Subject", "Subject")
                        .WithMany("Exams")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDataLibrary.Models.ProfessorSubject", b =>
                {
                    b.HasOne("EFDataLibrary.Models.Professor", "Professor")
                        .WithMany("Subjects")
                        .HasForeignKey("Professor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataLibrary.Models.Subject", "Subject")
                        .WithMany("Professors")
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

#pragma warning restore 612, 618
        }
    }
}
