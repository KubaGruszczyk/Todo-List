﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Entities;

#nullable disable

namespace TodoList.Migrations
{
    [DbContext(typeof(WorkTaskDBContext))]
    partial class WorkTaskDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoList.Entities.WorkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 16, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2282),
                            Description = "Skosic trawe wokol domu. Wyczyscic kosiarke po wykonaniu zadania oraz odlozyc na miejsce w garazu.",
                            ExpectedEndDate = new DateTime(2024, 10, 23, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2255),
                            IsCompleted = false,
                            Title = "Skosic Trawe"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 14, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2286),
                            Description = "Odkurzyc w kazdym pokoju po czym zmyc podlogi.",
                            ExpectedEndDate = new DateTime(2024, 10, 20, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2285),
                            IsCompleted = false,
                            Title = "Posprzatac w domu"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
