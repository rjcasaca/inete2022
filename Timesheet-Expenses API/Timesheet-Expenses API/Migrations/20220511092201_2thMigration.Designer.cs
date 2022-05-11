﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timesheet_Expenses_API.Models;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    [DbContext(typeof(_DbContext))]
    [Migration("20220511092201_2thMigration")]
    partial class _2thMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity", b =>
                {
                    b.Property<int>("Activity_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Activity_Id"), 1L, 1);

                    b.Property<int>("ActivityState_Id")
                        .HasColumnType("int");

                    b.Property<int>("ActivityType_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.HasKey("Activity_Id");

                    b.HasIndex("ActivityState_Id");

                    b.HasIndex("ActivityType_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Activity");
                });

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

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ActivityType", b =>
                {
                    b.Property<int>("ActivityType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityType_Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ActivityType_Id");

                    b.ToTable("Activity Type");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.BilingType", b =>
                {
                    b.Property<int>("BilingType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BilingType_Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BilingType_Id");

                    b.ToTable("Biling Type");
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

                    b.HasKey("Client_Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Comment", b =>
                {
                    b.Property<int>("Comment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Comment_Id"), 1L, 1);

                    b.Property<int>("Activity_Id")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Comment_Id");

                    b.HasIndex("Activity_Id");

                    b.ToTable("Comment");
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

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContent", b =>
                {
                    b.Property<int>("FileContent_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileContent_Id"), 1L, 1);

                    b.Property<int>("FileContTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("FileContent_Id");

                    b.HasIndex("FileContTypeId");

                    b.ToTable("File Content");
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

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProjectStateProjState_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Project_Id");

                    b.HasIndex("Client_Id");

                    b.HasIndex("ProjectStateProjState_Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ProjectState", b =>
                {
                    b.Property<int>("ProjState_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjState_Id"), 1L, 1);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProjState_Id");

                    b.ToTable("Project State");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Team", b =>
                {
                    b.Property<int>("projectID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserFunctionUserFunc_Id")
                        .HasColumnType("int");

                    b.HasKey("projectID", "userID");

                    b.HasIndex("UserFunctionUserFunc_Id");

                    b.HasIndex("userID");

                    b.ToTable("Team");
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

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Worklog", b =>
                {
                    b.Property<int>("Cod_Worklog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Worklog"), 1L, 1);

                    b.Property<int>("Activity_Id")
                        .HasColumnType("int");

                    b.Property<int>("BilingType_Id")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("WorklogState_Id")
                        .HasColumnType("int");

                    b.HasKey("Cod_Worklog");

                    b.HasIndex("Activity_Id");

                    b.HasIndex("BilingType_Id");

                    b.HasIndex("User_Id");

                    b.HasIndex("WorklogState_Id");

                    b.ToTable("Worklog");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.WorklogState", b =>
                {
                    b.Property<int>("WorklogState_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorklogState_Id"), 1L, 1);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WorklogState_Id");

                    b.ToTable("Worklog State");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.ActivityState", "ActivityState")
                        .WithMany("Activity")
                        .HasForeignKey("ActivityState_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.ActivityType", "ActivityType")
                        .WithMany("Activity")
                        .HasForeignKey("ActivityType_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.Project", "Project")
                        .WithMany("Activity")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityState");

                    b.Navigation("ActivityType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Comment", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Activity", "Activity")
                        .WithMany("Comment")
                        .HasForeignKey("Activity_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContent", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.FileContType", "FileContType")
                        .WithMany("FileContent")
                        .HasForeignKey("FileContTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileContType");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Client", "Client")
                        .WithMany("Project")
                        .HasForeignKey("Client_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.ProjectState", "ProjectState")
                        .WithMany("Project")
                        .HasForeignKey("ProjectStateProjState_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ProjectState");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Team", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.UserFunction", "UserFunction")
                        .WithMany()
                        .HasForeignKey("UserFunctionUserFunc_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.Project", "project")
                        .WithMany("Team")
                        .HasForeignKey("projectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", "user")
                        .WithMany("Team")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFunction");

                    b.Navigation("project");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Worklog", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Activity", "Activity")
                        .WithMany("Worklog")
                        .HasForeignKey("Activity_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.BilingType", "BilingType")
                        .WithMany("Worklog")
                        .HasForeignKey("BilingType_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", "User")
                        .WithMany("Worklog")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.WorklogState", "WorklogState")
                        .WithMany("Worklog")
                        .HasForeignKey("WorklogState_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("BilingType");

                    b.Navigation("User");

                    b.Navigation("WorklogState");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("Worklog");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ActivityState", b =>
                {
                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ActivityType", b =>
                {
                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.BilingType", b =>
                {
                    b.Navigation("Worklog");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Client", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContType", b =>
                {
                    b.Navigation("FileContent");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.Navigation("Activity");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ProjectState", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.User", b =>
                {
                    b.Navigation("Team");

                    b.Navigation("Worklog");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.WorklogState", b =>
                {
                    b.Navigation("Worklog");
                });
#pragma warning restore 612, 618
        }
    }
}
