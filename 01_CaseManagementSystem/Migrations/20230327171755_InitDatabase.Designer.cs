﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _01_CaseManagementSystem.Contexts;

#nullable disable

namespace _01_CaseManagementSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230327171755_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ErrorEntityId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("char(5)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ErrorEntityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ErrorEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdateComment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ErrorEntityId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.ErrorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ErrorTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdateComment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.TenantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("AddressesId")
                        .HasColumnType("int");

                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ErrorId")
                        .HasColumnType("int");

                    b.Property<int>("ErrorsId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("char(10)");

                    b.HasKey("Id");

                    b.HasIndex("AddressesId");

                    b.HasIndex("CommentsId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ErrorsId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.AddressEntity", b =>
                {
                    b.HasOne("_01_CaseManagementSystem.Models.Entities.ErrorEntity", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ErrorEntityId");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.CommentEntity", b =>
                {
                    b.HasOne("_01_CaseManagementSystem.Models.Entities.ErrorEntity", null)
                        .WithMany("Comments")
                        .HasForeignKey("ErrorEntityId");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.TenantEntity", b =>
                {
                    b.HasOne("_01_CaseManagementSystem.Models.Entities.AddressEntity", "Addresses")
                        .WithMany()
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_CaseManagementSystem.Models.Entities.CommentEntity", "Comments")
                        .WithMany("Tenants")
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_CaseManagementSystem.Models.Entities.ErrorEntity", "Errors")
                        .WithMany("Tenants")
                        .HasForeignKey("ErrorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addresses");

                    b.Navigation("Comments");

                    b.Navigation("Errors");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.CommentEntity", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("_01_CaseManagementSystem.Models.Entities.ErrorEntity", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Comments");

                    b.Navigation("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
