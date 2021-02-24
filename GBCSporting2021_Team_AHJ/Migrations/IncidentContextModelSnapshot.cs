﻿// <auto-generated />
using System;
using GBCSporting2021_Team_AHJ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GBCSporting2021_Team_AHJ.Migrations
{
    [DbContext(typeof(IncidentContext))]
    partial class IncidentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = "kor",
                            Name = "Korea"
                        },
                        new
                        {
                            CountryId = "can",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = "usa",
                            Name = "USA"
                        },
                        new
                        {
                            CountryId = "jpn",
                            Name = "Japan"
                        },
                        new
                        {
                            CountryId = "ger",
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "120 Dundas street",
                            City = "Toronto",
                            CountryId = "can",
                            Email = "abcde@gmail.com",
                            FirstName = "Jason",
                            LastName = "Kim",
                            Phone = "437-684-1234",
                            PostalCode = "M2K 2EK",
                            State = "Ontario"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "222 Seoul-ro",
                            City = "Jung-gu",
                            CountryId = "kor",
                            Email = "Suho.lee@gmail.com",
                            FirstName = "Suho",
                            LastName = "Lee",
                            Phone = "010-1234-1234",
                            PostalCode = "04515",
                            State = "Seoul"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "511-5762 At Rd",
                            City = "Chelsea",
                            CountryId = "usa",
                            Email = "julie.baker@gmail.com",
                            FirstName = "Julie",
                            LastName = "Baker",
                            Phone = "947-278-1234",
                            PostalCode = "67708",
                            State = "MI"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 1,
                            DateClosed = new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(2021, 2, 24, 16, 15, 54, 170, DateTimeKind.Local).AddTicks(4836),
                            Description = "The file seems like broken, so need to re-download",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 2,
                            DateClosed = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(2021, 2, 24, 16, 15, 54, 171, DateTimeKind.Local).AddTicks(2364),
                            Description = "Error occurs in some point.",
                            ProductId = 2,
                            TechnicianId = 2,
                            Title = "Error importing data"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 3,
                            DateClosed = new DateTime(2021, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(2021, 2, 24, 16, 15, 54, 171, DateTimeKind.Local).AddTicks(2390),
                            Description = "Error occur when is launching program",
                            ProductId = 3,
                            TechnicianId = 3,
                            Title = "Error launching program"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Code = "TRNY10",
                            Name = "Draft Manager 1.0",
                            Price = 10.0,
                            ReleaseDate = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 2,
                            Code = "LEAG10",
                            Name = "Tournament Master 1.0",
                            Price = 20.0,
                            ReleaseDate = new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 3,
                            Code = "LEAGD10",
                            Name = "League Scheduler",
                            Price = 30.0,
                            ReleaseDate = new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Registration", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "alison.diaz@gmail.com",
                            Name = "Alison Diaz",
                            Phone = "437-987-6654"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "kevin.smith@gmail.com",
                            Name = "Kevin Smith",
                            Phone = "437-222-2222"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "servie.garcia@gmail.com",
                            Name = "Servie Garcia",
                            Phone = "437-333-3333"
                        });
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Customer", b =>
                {
                    b.HasOne("GBCSporting2021_Team_AHJ.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Incident", b =>
                {
                    b.HasOne("GBCSporting2021_Team_AHJ.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting2021_Team_AHJ.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting2021_Team_AHJ.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Registration", b =>
                {
                    b.HasOne("GBCSporting2021_Team_AHJ.Models.Customer", "Customer")
                        .WithMany("Registrations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting2021_Team_AHJ.Models.Product", "Product")
                        .WithMany("Registrations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Customer", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("GBCSporting2021_Team_AHJ.Models.Product", b =>
                {
                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
