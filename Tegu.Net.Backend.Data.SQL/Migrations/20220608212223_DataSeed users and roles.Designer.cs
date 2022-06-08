﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tegu.Net.Backend.Data.SQL.Context;

#nullable disable

namespace Tegu.Net.Backend.Data.SQL.Migrations
{
    [DbContext(typeof(TeguSqlContext))]
    [Migration("20220608212223_DataSeed users and roles")]
    partial class DataSeedusersandroles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.OwnedTegu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TeguTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TeguTypeId");

                    b.ToTable("OwnedTegus");
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tegu"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Client"
                        });
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.TeguType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LatinName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TeguTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Black & White",
                            FullName = "Argentine Black and White Tegu",
                            LatinName = "Salvator Merianae",
                            Name = "B&W Tegu"
                        },
                        new
                        {
                            Id = 2,
                            Color = "Red",
                            FullName = "Argentine Red Tegu",
                            LatinName = "Salvator Rufescens",
                            Name = "Red Tegu"
                        },
                        new
                        {
                            Id = 3,
                            Color = "Gold",
                            FullName = "Colombian Tegu",
                            LatinName = "Tupinambis Teguixin",
                            Name = "Gold Tegu"
                        });
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"),
                            Email = "admintegu@tegu.net",
                            FirstName = "Admin",
                            LastName = "Tegu",
                            PasswordHash = "$2a$11$E67YeDjnVXx47x7aPanznu2BT6Yql.0i1EvuY3MQhM4KcxbN9ljbu"
                        },
                        new
                        {
                            Id = new Guid("079f5040-3662-4897-b827-d3505ea2438a"),
                            Email = "bwtegu@tegu.net",
                            FirstName = "B&W",
                            LastName = "Tegu",
                            PasswordHash = "$2a$11$z9bxZR2dYitdeBHvV1dVDOvERirnnEDkEwAH0tBxwunzFU0Z7omRG"
                        },
                        new
                        {
                            Id = new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"),
                            Email = "mixedtegu@tegu.net",
                            FirstName = "Mixed",
                            LastName = "Tegu",
                            PasswordHash = "$2a$11$cMGAh5FAcAnSd53qRDwq8OaEZlnqVE39l5cZ7mTE3KZmHli55wsnG"
                        },
                        new
                        {
                            Id = new Guid("28218d70-5b0d-4d19-8171-1cae6ae75d30"),
                            Email = "notegu@tegu.net",
                            FirstName = "No",
                            LastName = "Tegu",
                            PasswordHash = "$2a$11$CYcwsHlqq1qV77xdsUae3.OsTWD3GCm5P7716vnVdsw1wJHeEdQZ2"
                        });
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"),
                            RoleId = 1
                        },
                        new
                        {
                            UserId = new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"),
                            RoleId = 2
                        },
                        new
                        {
                            UserId = new Guid("079f5040-3662-4897-b827-d3505ea2438a"),
                            RoleId = 2
                        },
                        new
                        {
                            UserId = new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"),
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.OwnedTegu", b =>
                {
                    b.HasOne("Tegu.Net.Backend.Data.SQL.Entities.User", "Owner")
                        .WithMany("OwnedTegus")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tegu.Net.Backend.Data.SQL.Entities.TeguType", "TeguType")
                        .WithMany("OwnedTegus")
                        .HasForeignKey("TeguTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("TeguType");
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.UserRole", b =>
                {
                    b.HasOne("Tegu.Net.Backend.Data.SQL.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tegu.Net.Backend.Data.SQL.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.TeguType", b =>
                {
                    b.Navigation("OwnedTegus");
                });

            modelBuilder.Entity("Tegu.Net.Backend.Data.SQL.Entities.User", b =>
                {
                    b.Navigation("OwnedTegus");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
