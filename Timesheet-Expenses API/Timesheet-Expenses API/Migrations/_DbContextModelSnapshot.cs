﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timesheet_Expenses_API.Models;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    [DbContext(typeof(_DbContext))]
    partial class _DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ActivityState", b =>
                {
                    b.Property<int>("ActivityState_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityState_Id"), 1L, 1);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ActivityState_Id");

                    b.ToTable("Activity State");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Client", b =>
                {
                    b.Property<int>("Client_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Client_Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.HasKey("Client_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ExpenseState", b =>
                {
                    b.Property<int>("ExpenseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseTypeId"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseTypeId");

                    b.ToTable("Expense Type");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContType", b =>
                {
                    b.Property<int>("FileContTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileContTypeId"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileContTypeId");

                    b.ToTable("FileCont Type");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.Property<int>("Project_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Project_Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Project_Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ProjectState", b =>
                {
                    b.Property<int>("ProjState_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjState_Id"), 1L, 1);

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProjState_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Project State");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Team", b =>
                {
                    b.Property<int>("Project")
                        .HasColumnType("int");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("functionUserFunc_Id")
                        .HasColumnType("int");

                    b.HasKey("Project", "User");

                    b.HasIndex("Project_Id");

                    b.HasIndex("User_Id");

                    b.HasIndex("functionUserFunc_Id");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("User_Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.UserFunction", b =>
                {
                    b.Property<int>("UserFunc_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFunc_Id"), 1L, 1);

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserFunc_Id");

                    b.ToTable("User Function");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Client", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Project", "Project")
                        .WithMany("Client")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ProjectState", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Project", "Project")
                        .WithMany("ProjectState")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Team", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Project", "project")
                        .WithMany("teams")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", "user")
                        .WithMany("teams")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.UserFunction", "function")
                        .WithMany("teams")
                        .HasForeignKey("functionUserFunc_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("function");

                    b.Navigation("project");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("ProjectState");

                    b.Navigation("teams");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.User", b =>
                {
                    b.Navigation("teams");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.UserFunction", b =>
                {
                    b.Navigation("teams");
                });
#pragma warning restore 612, 618
        }
    }
}
