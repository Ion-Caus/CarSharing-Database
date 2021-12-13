﻿// <auto-generated />
using System;
using Database_EFC.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarSharing_Database_GraphQL.Migrations
{
    [DbContext(typeof(CarSharingDbContext))]
    [Migration("20211211204201_7_Add_Access_Level_Admin")]
    partial class _7_Add_Access_Level_Admin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Entity.ModelData.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<string>("CustomerCpr")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.HasIndex("CustomerCpr");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Entity.ModelData.Coupon", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.HasKey("Code");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Entity.ModelData.Customer", b =>
                {
                    b.Property<string>("Cpr")
                        .HasColumnType("text");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Cpr");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entity.ModelData.Lease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Canceled")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomerCpr")
                        .HasColumnType("text");

                    b.Property<DateTime>("LeasedFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LeasedTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ListingId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerCpr");

                    b.HasIndex("ListingId");

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("Entity.ModelData.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

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

            modelBuilder.Entity("Entity.ModelData.Vehicle", b =>
                {
                    b.Property<string>("LicenseNo")
                        .HasColumnType("text");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("FuelType")
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

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

                    b.HasIndex("OwnerCpr");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Entity.ModelData.Account", b =>
                {
                    b.HasOne("Entity.ModelData.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCpr");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entity.ModelData.Lease", b =>
                {
                    b.HasOne("Entity.ModelData.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCpr");

                    b.HasOne("Entity.ModelData.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId");

                    b.Navigation("Customer");

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("Entity.ModelData.Listing", b =>
                {
                    b.HasOne("Entity.ModelData.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleLicenseNo");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Entity.ModelData.Vehicle", b =>
                {
                    b.HasOne("Entity.ModelData.Customer", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerCpr");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
