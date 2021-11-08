﻿// <auto-generated />
using System;
using CarSharing_Database_GraphQL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarSharing_Database_GraphQL.Migrations
{
    [DbContext(typeof(CarSharingDbContext))]
    [Migration("20211108153458_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CarSharing_Database_GraphQL.ModelData.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ListedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("VehicleLicenseNo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("VehicleLicenseNo");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("CarSharing_Database_GraphQL.ModelData.Vehicle", b =>
                {
                    b.Property<string>("LicenseNo")
                        .HasColumnType("text");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("FuelType")
                        .HasColumnType("text");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("integer");

                    b.Property<double>("Mileage")
                        .HasColumnType("double precision");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("OwnerCpr")
                        .HasColumnType("text");

                    b.Property<int>("Seats")
                        .HasColumnType("integer");

                    b.Property<string>("Transmission")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("LicenseNo");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarSharing_Database_GraphQL.ModelData.Listing", b =>
                {
                    b.HasOne("CarSharing_Database_GraphQL.ModelData.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleLicenseNo");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
