﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticeProject.Models;

#nullable disable

namespace PracticeProject.Migrations
{
    [DbContext(typeof(EmployerProjectDbContext))]
    partial class EmployerProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PracticeProject.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("PracticeProject.Models.EmployerProject", b =>
                {
                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployerId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployerProjects");
                });

            modelBuilder.Entity("PracticeProject.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PracticeProject.Models.EmployerProject", b =>
                {
                    b.HasOne("PracticeProject.Models.Employer", "Employer")
                        .WithMany("EmployerProjects")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticeProject.Models.Project", "Project")
                        .WithMany("EmployerProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PracticeProject.Models.Employer", b =>
                {
                    b.Navigation("EmployerProjects");
                });

            modelBuilder.Entity("PracticeProject.Models.Project", b =>
                {
                    b.Navigation("EmployerProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
