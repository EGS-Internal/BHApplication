﻿// <auto-generated />
using System;
using BHGroup.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BHGroup.DAL.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240322080416_finalUpdate")]
    partial class finalUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BHGroup.DAL.Entities.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("course_code");

                    b.Property<string>("Coursename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("course_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("staff_code")
                        .HasColumnType("int");

                    b.HasKey("CourseID");

                    b.HasIndex("staff_code");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("BHGroup.DAL.Entities.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("int")
                        .HasColumnName("grade");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("semester");

                    b.Property<int>("course_code")
                        .HasColumnType("int");

                    b.Property<int>("student_code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("course_code");

                    b.HasIndex("student_code");

                    b.ToTable("enrollments");
                });

            modelBuilder.Entity("BHGroup.DAL.Entities.Lecturer", b =>
                {
                    b.Property<int>("StaffCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_code")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffCode"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(8)
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("join_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("StaffCode");

                    b.ToTable("lecturers");
                });

            modelBuilder.Entity("BHGroup.DAL.Entities.Student", b =>
                {
                    b.Property<int>("StudentCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_code")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCode"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(8)
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("join_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("StudentCode");

                    b.ToTable("students");
                });

            modelBuilder.Entity("BHGroup.DAL.Entities.Course", b =>
                {
                    b.HasOne("BHGroup.DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("Courses")
                        .HasForeignKey("staff_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("BHGroup.DAL.Entities.Enrollment", b =>
                {
                    b.HasOne("BHGroup.DAL.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("course_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BHGroup.DAL.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("student_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BHGroup.DAL.Entities.Lecturer", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
