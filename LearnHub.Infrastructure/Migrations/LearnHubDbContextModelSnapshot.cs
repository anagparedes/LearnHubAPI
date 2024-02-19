﻿// <auto-generated />
using System;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnHub.Infrastructure.Migrations
{
    [DbContext(typeof(LearnHubDbContext))]
    partial class LearnHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssignmentStudent", b =>
                {
                    b.Property<int>("AssignedAssignmentsId")
                        .HasColumnType("int");

                    b.Property<int>("AssignedStudentsId")
                        .HasColumnType("int");

                    b.HasKey("AssignedAssignmentsId", "AssignedStudentsId");

                    b.HasIndex("AssignedStudentsId");

                    b.ToTable("AssignmentStudent");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssignmentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentResponse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CreatedTeacherId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("courseType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedTeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EvaluatedTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("QualificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("EvaluatedTeacherId");

                    b.HasIndex("StudentId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("LearnHub.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Student", b =>
                {
                    b.HasBaseType("LearnHub.Domain.Entities.User");

                    b.Property<string>("Career")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Career")
                                .HasColumnName("Student_Career");

                            t.Property("Gender")
                                .HasColumnName("Student_Gender");

                            t.Property("IdentificationCard")
                                .HasColumnName("Student_IdentificationCard");

                            t.Property("Status")
                                .HasColumnName("Student_Status");

                            t.Property("Telephone")
                                .HasColumnName("Student_Telephone");
                        });

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Teacher", b =>
                {
                    b.HasBaseType("LearnHub.Domain.Entities.User");

                    b.Property<string>("Career")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("careerArea")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("AssignmentStudent", b =>
                {
                    b.HasOne("LearnHub.Domain.Entities.Assignment", null)
                        .WithMany()
                        .HasForeignKey("AssignedAssignmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnHub.Domain.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("AssignedStudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("LearnHub.Domain.Entities.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId");

                    b.HasOne("LearnHub.Domain.Entities.Teacher", "CreatedTeacher")
                        .WithMany("CreatedAssignments")
                        .HasForeignKey("CreatedTeacherId");

                    b.Navigation("Course");

                    b.Navigation("CreatedTeacher");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Course", b =>
                {
                    b.HasOne("LearnHub.Domain.Entities.Teacher", "AssignedTeacher")
                        .WithMany("Courses")
                        .HasForeignKey("AssignedTeacherId");

                    b.Navigation("AssignedTeacher");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Qualification", b =>
                {
                    b.HasOne("LearnHub.Domain.Entities.Assignment", "Assignment")
                        .WithMany("Qualifications")
                        .HasForeignKey("AssignmentId");

                    b.HasOne("LearnHub.Domain.Entities.Teacher", "EvaluatedTeacher")
                        .WithMany("Grades")
                        .HasForeignKey("EvaluatedTeacherId");

                    b.HasOne("LearnHub.Domain.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId");

                    b.Navigation("Assignment");

                    b.Navigation("EvaluatedTeacher");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.StudentCourse", b =>
                {
                    b.HasOne("LearnHub.Domain.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnHub.Domain.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Assignment", b =>
                {
                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("LearnHub.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("CreatedAssignments");

                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
