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

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity", b =>
                {
                    b.Property<int>("Activity_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Activity_Id"), 1L, 1);

                    b.Property<int>("ActivityStateId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Activity_Id");

                    b.HasIndex("ActivityStateId");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity_File", b =>
                {
                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("FileContentId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId", "FileContentId");

                    b.HasIndex("FileContentId");

                    b.ToTable("Activity_File");
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

            modelBuilder.Entity("Timesheet_Expenses_API.Models.BillingType", b =>
                {
                    b.Property<int>("BillingType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingType_Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BillingType_Id");

                    b.ToTable("Billing Type");
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

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Expense", b =>
                {
                    b.Property<int>("Expense_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Expense_Id"), 1L, 1);

                    b.Property<string>("ExpenseState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpenseState_Id")
                        .HasColumnType("int");

                    b.Property<int?>("ExpenseType_Id")
                        .HasColumnType("int");

                    b.Property<string>("Expense_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Expense_Id");

                    b.HasIndex("ExpenseState_Id");

                    b.HasIndex("ExpenseType_Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Expense_File", b =>
                {
                    b.Property<int>("FileContentId")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseId")
                        .HasColumnType("int");

                    b.HasKey("FileContentId", "ExpenseId");

                    b.HasIndex("ExpenseId");

                    b.ToTable("Expense_File");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ExpenseState", b =>
                {
                    b.Property<int>("ExpenseState_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseState_Id"), 1L, 1);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ExpenseState_Id");

                    b.ToTable("Expense State");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ExpenseType", b =>
                {
                    b.Property<int>("ExpenseType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseType_Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ExpenseType_Id");

                    b.ToTable("Expense Type");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.File", b =>
                {
                    b.Property<int>("File_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("File_Id"), 1L, 1);

                    b.Property<string>("base64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("File_Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContent", b =>
                {
                    b.Property<int>("FileContent_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileContent_Id"), 1L, 1);

                    b.Property<int>("FileContentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("FileContent_Id");

                    b.HasIndex("FileContentTypeId");

                    b.HasIndex("FileId");

                    b.ToTable("File Content");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContentType", b =>
                {
                    b.Property<int>("FileContentType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileContentType_Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FileContentType_Id");

                    b.ToTable("File Content Type");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Line", b =>
                {
                    b.Property<int>("Cod_Line")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Line"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpenseId")
                        .HasColumnType("int");

                    b.Property<int?>("LineCityID")
                        .HasColumnType("int");

                    b.Property<int?>("LineTypeID")
                        .HasColumnType("int");

                    b.Property<decimal>("UnityPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("lineCIty")
                        .HasColumnType("int");

                    b.Property<int>("lineType")
                        .HasColumnType("int");

                    b.HasKey("Cod_Line");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("LineCityID");

                    b.HasIndex("LineTypeID");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.LineCity", b =>
                {
                    b.Property<int>("LineCityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineCityID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LineCityID");

                    b.ToTable("LineCity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.LineType", b =>
                {
                    b.Property<int>("LineTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineTypeID"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LineTypeID");

                    b.ToTable("LineType");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.Property<int>("Project_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Project_Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProjectStateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Project_Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectStateId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ProjectState", b =>
                {
                    b.Property<int>("ProjectState_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectState_Id"), 1L, 1);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProjectState_Id");

                    b.ToTable("Project State");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Team", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserFunctionId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserFunctionId");

                    b.HasIndex("UserId");

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

                    b.ToTable("ArquiUsers");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.User_Activity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("User_Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.UserFunction", b =>
                {
                    b.Property<int>("UserFunction_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFunction_Id"), 1L, 1);

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserFunction_Id");

                    b.ToTable("User Function");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Worklog", b =>
                {
                    b.Property<int>("Cod_Worklog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Worklog"), 1L, 1);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("BillingTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorklogStateId")
                        .HasColumnType("int");

                    b.HasKey("Cod_Worklog");

                    b.HasIndex("ActivityId");

                    b.HasIndex("BillingTypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorklogStateId");

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
                        .HasForeignKey("ActivityStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.ActivityType", "ActivityType")
                        .WithMany("Activity")
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.Project", "Project")
                        .WithMany("Activity")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityState");

                    b.Navigation("ActivityType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity_File", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Activity", "Activity")
                        .WithMany("Activity_File")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.FileContent", "FileContent")
                        .WithMany("Activity_File")
                        .HasForeignKey("FileContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("FileContent");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Expense", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.ExpenseState", null)
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseState_Id");

                    b.HasOne("Timesheet_Expenses_API.Models.ExpenseType", null)
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseType_Id");

                    b.HasOne("Timesheet_Expenses_API.Models.Project", null)
                        .WithMany("Expenses")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", null)
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Expense_File", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Expense", "Expenses")
                        .WithMany()
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.FileContent", "FileContent")
                        .WithMany("Expense_File")
                        .HasForeignKey("FileContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expenses");

                    b.Navigation("FileContent");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContent", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.FileContentType", "FileContentType")
                        .WithMany()
                        .HasForeignKey("FileContentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("FileContentType");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Line", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Expense", "Expense")
                        .WithMany("Line")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.LineCity", null)
                        .WithMany("line")
                        .HasForeignKey("LineCityID");

                    b.HasOne("Timesheet_Expenses_API.Models.LineType", null)
                        .WithMany("line")
                        .HasForeignKey("LineTypeID");

                    b.Navigation("Expense");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Client", "Client")
                        .WithMany("Project")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.ProjectState", "ProjectState")
                        .WithMany("Project")
                        .HasForeignKey("ProjectStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ProjectState");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Team", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Project", "project")
                        .WithMany("Team")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.UserFunction", "UserFunction")
                        .WithMany()
                        .HasForeignKey("UserFunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", "user")
                        .WithMany("Team")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFunction");

                    b.Navigation("project");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.User_Activity", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Activity", "activity")
                        .WithMany("user_Activities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", "user")
                        .WithMany("user_Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("activity");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Worklog", b =>
                {
                    b.HasOne("Timesheet_Expenses_API.Models.Activity", "Activity")
                        .WithMany("Worklog")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.BillingType", "BillingType")
                        .WithMany("Worklog")
                        .HasForeignKey("BillingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.User", "User")
                        .WithMany("Worklog")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Expenses_API.Models.WorklogState", "WorklogState")
                        .WithMany("Worklog")
                        .HasForeignKey("WorklogStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("BillingType");

                    b.Navigation("User");

                    b.Navigation("WorklogState");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Activity", b =>
                {
                    b.Navigation("Activity_File");

                    b.Navigation("Worklog");

                    b.Navigation("user_Activities");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ActivityState", b =>
                {
                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ActivityType", b =>
                {
                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.BillingType", b =>
                {
                    b.Navigation("Worklog");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Client", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Expense", b =>
                {
                    b.Navigation("Line");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ExpenseState", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ExpenseType", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.FileContent", b =>
                {
                    b.Navigation("Activity_File");

                    b.Navigation("Expense_File");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.LineCity", b =>
                {
                    b.Navigation("line");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.LineType", b =>
                {
                    b.Navigation("line");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.Project", b =>
                {
                    b.Navigation("Activity");

                    b.Navigation("Expenses");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.ProjectState", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.User", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Team");

                    b.Navigation("Worklog");

                    b.Navigation("user_Activities");
                });

            modelBuilder.Entity("Timesheet_Expenses_API.Models.WorklogState", b =>
                {
                    b.Navigation("Worklog");
                });
#pragma warning restore 612, 618
        }
    }
}
