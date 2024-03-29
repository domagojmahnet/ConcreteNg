﻿// <auto-generated />
using System;
using ConcreteNg.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConcreteNg.Shared.Models.DiaryItem", b =>
                {
                    b.Property<int>("DiaryItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiaryItemId"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("DiaryItemId");

                    b.HasIndex("ProjectId");

                    b.ToTable("DiaryItems");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Employer", b =>
                {
                    b.Property<int>("EmployerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("EmployerId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"), 1L, 1);

                    b.Property<int>("ExpenseType")
                        .HasColumnType("int");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectTaskItemId")
                        .HasColumnType("int");

                    b.Property<float?>("Quantity")
                        .HasColumnType("real");

                    b.Property<float?>("TotalCost")
                        .HasColumnType("real");

                    b.HasKey("ExpenseId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("ProjectTaskItemId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Partner", b =>
                {
                    b.Property<int>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartnerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartnerId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.PricingListItem", b =>
                {
                    b.Property<int>("PricingListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricingListItemId"), 1L, 1);

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("PricingListItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PricingListItemId");

                    b.HasIndex("EmployerId");

                    b.ToTable("PricingListItems");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<float>("CurrentCost")
                        .HasColumnType("real");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<float>("ExpectedCost")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset>("ExpectedEndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ExpectedStartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ProjectId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectTaskId"), 1L, 1);

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectTaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectTaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.ProjectTaskItem", b =>
                {
                    b.Property<int>("ProjectTaskItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectTaskItemId"), 1L, 1);

                    b.Property<float?>("Expenditure")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset?>("FinishTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PricingListItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectTaskId")
                        .HasColumnType("int");

                    b.Property<float?>("Quantity")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TaskItemStatus")
                        .HasColumnType("int");

                    b.HasKey("ProjectTaskItemId");

                    b.HasIndex("PricingListItemId");

                    b.HasIndex("ProjectTaskId");

                    b.ToTable("ProjectTaskItems");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("HireDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsProjectId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.DiaryItem", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Expense", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId");

                    b.HasOne("ConcreteNg.Shared.Models.ProjectTaskItem", "ProjectTaskItem")
                        .WithMany()
                        .HasForeignKey("ProjectTaskItemId");

                    b.Navigation("Partner");

                    b.Navigation("ProjectTaskItem");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.File", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Partner", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.PricingListItem", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.Project", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.ProjectTask", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.ProjectTaskItem", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.PricingListItem", "PricingListItem")
                        .WithMany()
                        .HasForeignKey("PricingListItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConcreteNg.Shared.Models.ProjectTask", "ProjectTask")
                        .WithMany("ProjectTaskItems")
                        .HasForeignKey("ProjectTaskId");

                    b.Navigation("PricingListItem");

                    b.Navigation("ProjectTask");
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.User", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("ConcreteNg.Shared.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConcreteNg.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConcreteNg.Shared.Models.ProjectTask", b =>
                {
                    b.Navigation("ProjectTaskItems");
                });
#pragma warning restore 612, 618
        }
    }
}
