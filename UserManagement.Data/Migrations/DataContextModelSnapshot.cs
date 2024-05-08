﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Data;

#nullable disable

namespace UserManagement.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserManagement.Models.ActionLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ActionLog", (string)null);
                });

            modelBuilder.Entity("UserManagement.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Forename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateOfBirth = new DateTime(1980, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ploew@example.com",
                            Forename = "Peter",
                            IsActive = true,
                            Surname = "Loew"
                        },
                        new
                        {
                            Id = 2L,
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bfgates@example.com",
                            Forename = "Benjamin Franklin",
                            IsActive = true,
                            Surname = "Gates"
                        },
                        new
                        {
                            Id = 3L,
                            DateOfBirth = new DateTime(1997, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ctroy@example.com",
                            Forename = "Castor",
                            IsActive = false,
                            Surname = "Troy"
                        },
                        new
                        {
                            Id = 4L,
                            DateOfBirth = new DateTime(1988, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mraines@example.com",
                            Forename = "Memphis",
                            IsActive = true,
                            Surname = "Raines"
                        },
                        new
                        {
                            Id = 5L,
                            DateOfBirth = new DateTime(1995, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sgodspeed@example.com",
                            Forename = "Stanley",
                            IsActive = true,
                            Surname = "Goodspeed"
                        },
                        new
                        {
                            Id = 6L,
                            DateOfBirth = new DateTime(1989, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "himcdunnough@example.com",
                            Forename = "H.I.",
                            IsActive = true,
                            Surname = "McDunnough"
                        },
                        new
                        {
                            Id = 7L,
                            DateOfBirth = new DateTime(1992, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cpoe@example.com",
                            Forename = "Cameron",
                            IsActive = false,
                            Surname = "Poe"
                        },
                        new
                        {
                            Id = 8L,
                            DateOfBirth = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emalus@example.com",
                            Forename = "Edward",
                            IsActive = false,
                            Surname = "Malus"
                        },
                        new
                        {
                            Id = 9L,
                            DateOfBirth = new DateTime(1999, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dmacready@example.com",
                            Forename = "Damon",
                            IsActive = false,
                            Surname = "Macready"
                        },
                        new
                        {
                            Id = 10L,
                            DateOfBirth = new DateTime(1989, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jblaze@example.com",
                            Forename = "Johnny",
                            IsActive = true,
                            Surname = "Blaze"
                        },
                        new
                        {
                            Id = 11L,
                            DateOfBirth = new DateTime(1996, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "rfeld@example.com",
                            Forename = "Robin",
                            IsActive = true,
                            Surname = "Feld"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
