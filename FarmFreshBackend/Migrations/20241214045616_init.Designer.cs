﻿// <auto-generated />
using System;
using FarmFreshBackend.DataSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmFreshBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241214045616_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Models.Roles.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RoleCode")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Core.Models.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}