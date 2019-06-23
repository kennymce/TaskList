﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskList.TaskListDB;

namespace taskList.Migrations
{
    [DbContext(typeof(TaskListDBContext))]
    [Migration("20190622075637_initialCommit")]
    partial class initialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskList.Models.Task", b =>
                {
                    b.Property<int>("taskId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateTimeCreated");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("taskName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("taskId");

                    b.ToTable("taskList");
                });
#pragma warning restore 612, 618
        }
    }
}
