﻿// <auto-generated />
using System;
using BillingSystem.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BillingSystem.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(BillingSystemDbContext))]
    [Migration("20230806145502_initMigration")]
    partial class initMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BillingSystem.Domain.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Floor")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<int>("Resident")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Apartment", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Block = "A",
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(128),
                            Floor = 1,
                            Number = 1,
                            Resident = 1,
                            Status = 1,
                            Type = "2+1",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(131)
                        },
                        new
                        {
                            Id = 2,
                            Block = "A",
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(134),
                            Floor = 1,
                            Number = 2,
                            Resident = 2,
                            Status = 1,
                            Type = "2+1",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(134)
                        },
                        new
                        {
                            Id = 3,
                            Block = "A",
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(136),
                            Floor = 2,
                            Number = 3,
                            Resident = 1,
                            Status = 0,
                            Type = "3+1",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(137)
                        },
                        new
                        {
                            Id = 4,
                            Block = "A",
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(138),
                            Floor = 2,
                            Number = 4,
                            Resident = 1,
                            Status = 0,
                            Type = "3+1",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(139)
                        },
                        new
                        {
                            Id = 5,
                            Block = "A",
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(140),
                            Floor = 3,
                            Number = 5,
                            Resident = 1,
                            Status = 0,
                            Type = "3+1",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(141)
                        },
                        new
                        {
                            Id = 6,
                            Block = "A",
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(143),
                            Floor = 3,
                            Number = 6,
                            Resident = 1,
                            Status = 0,
                            Type = "3+1",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(143)
                        });
                });

            modelBuilder.Entity("BillingSystem.Domain.Dues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amounth")
                        .HasMaxLength(50)
                        .HasColumnType("numeric");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DuesPaymentStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Year")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Dues", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amounth = 200m,
                            ApartmentId = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(491),
                            DuesPaymentStatus = 0,
                            Month = "July",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(491),
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Amounth = 200m,
                            ApartmentId = 2,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(494),
                            DuesPaymentStatus = 0,
                            Month = "July",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(494),
                            Year = 2023
                        },
                        new
                        {
                            Id = 3,
                            Amounth = 200m,
                            ApartmentId = 3,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(496),
                            DuesPaymentStatus = 0,
                            Month = "July",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(496),
                            Year = 2023
                        });
                });

            modelBuilder.Entity("BillingSystem.Domain.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amounth")
                        .HasMaxLength(50)
                        .HasColumnType("numeric");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InvoicePaymentStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("InvoiceType")
                        .HasColumnType("integer");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Year")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Invoice", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amounth = 200m,
                            ApartmentId = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(515),
                            InvoicePaymentStatus = 0,
                            InvoiceType = 1,
                            Month = "July",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(516),
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Amounth = 200m,
                            ApartmentId = 2,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(518),
                            InvoicePaymentStatus = 0,
                            InvoiceType = 2,
                            Month = "July",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(519),
                            Year = 2023
                        },
                        new
                        {
                            Id = 3,
                            Amounth = 200m,
                            ApartmentId = 3,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(520),
                            InvoicePaymentStatus = 0,
                            InvoiceType = 3,
                            Month = "July",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(521),
                            Year = 2023
                        });
                });

            modelBuilder.Entity("BillingSystem.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("CarPlateNumber")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("TCKNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("User", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentId = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(336),
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Password = "admin",
                            Phone = "0567 456 43 43",
                            Role = "Admin",
                            TCKNumber = "11111111111",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(337)
                        },
                        new
                        {
                            Id = 2,
                            ApartmentId = 2,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(340),
                            Email = "nisa@gmail.com",
                            FirstName = "Nisa",
                            LastName = "Turhan",
                            Password = "123456",
                            Phone = "0567 456 43 43",
                            Role = "User",
                            TCKNumber = "22222222222",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(340)
                        },
                        new
                        {
                            Id = 3,
                            ApartmentId = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(460),
                            Email = "doga@gmail.com",
                            FirstName = "Doğa",
                            LastName = "Turhan",
                            Password = "123456",
                            Phone = "0567 456 43 43",
                            Role = "User",
                            TCKNumber = "33333333333",
                            UpdatedDate = new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(461)
                        });
                });

            modelBuilder.Entity("BillingSystem.Domain.Dues", b =>
                {
                    b.HasOne("BillingSystem.Domain.Apartment", "Apartment")
                        .WithMany("Dues")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("BillingSystem.Domain.Invoice", b =>
                {
                    b.HasOne("BillingSystem.Domain.Apartment", "Apartment")
                        .WithMany("Invoices")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("BillingSystem.Domain.User", b =>
                {
                    b.HasOne("BillingSystem.Domain.Apartment", "Apartment")
                        .WithMany("Users")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("BillingSystem.Domain.Apartment", b =>
                {
                    b.Navigation("Dues");

                    b.Navigation("Invoices");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}