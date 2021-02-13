﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBroidery;

namespace MyBroidery.Migrations
{
    [DbContext(typeof(MyBroideryContext))]
    [Migration("20210207183059_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("MyBroidery.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyBroidery.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Guest"
                        });
                });

            modelBuilder.Entity("MyBroidery.Entities.RolePrivilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Privilege")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePrivilege");

                    b.HasData(
                        new
                        {
                            Id = 16,
                            Privilege = "own_account_read",
                            RoleId = 13
                        },
                        new
                        {
                            Id = 17,
                            Privilege = "account_create",
                            RoleId = 13
                        },
                        new
                        {
                            Id = 18,
                            Privilege = "own_account_update",
                            RoleId = 13
                        },
                        new
                        {
                            Id = 19,
                            Privilege = "own_account_delete",
                            RoleId = 13
                        },
                        new
                        {
                            Id = 20,
                            Privilege = "product_read",
                            RoleId = 13
                        },
                        new
                        {
                            Id = 2,
                            Privilege = "account_list",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            Privilege = "product_list",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Privilege = "product_create",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            Privilege = "product_update",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            Privilege = "product_delete",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 7,
                            Privilege = "account_delete",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 8,
                            Privilege = "own_account_read",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 9,
                            Privilege = "account_create",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 10,
                            Privilege = "own_account_update",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 11,
                            Privilege = "own_account_delete",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 12,
                            Privilege = "product_read",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("MyBroidery.Entities.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("MyBroidery.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 15,
                            Username = "Guest"
                        });
                });

            modelBuilder.Entity("MyBroidery.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 14,
                            RoleId = 13,
                            UserId = 15
                        });
                });

            modelBuilder.Entity("MyBroidery.Entities.Product", b =>
                {
                    b.HasOne("MyBroidery.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBroidery.Entities.RolePrivilege", b =>
                {
                    b.HasOne("MyBroidery.Entities.Role", "Role")
                        .WithMany("Privileges")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBroidery.Entities.Token", b =>
                {
                    b.HasOne("MyBroidery.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBroidery.Entities.UserRole", b =>
                {
                    b.HasOne("MyBroidery.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBroidery.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
