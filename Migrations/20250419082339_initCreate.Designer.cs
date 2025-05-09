﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateAgencySystem.Models;

#nullable disable

namespace RealEstateAgencySystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250419082339_initCreate")]
    partial class initCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<int>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ImageId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ListingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerCustomerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("RentalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("SizeOfHouse")
                        .HasColumnType("REAL");

                    b.HasKey("PropertyId");

                    b.HasIndex("OwnerCustomerId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.PropertyAmenities", b =>
                {
                    b.Property<int>("PropertyAmenitiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Cooktop")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Dishwasher")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Dryer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Elevator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FireSprinklerSystem")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FitnessRoom")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Heating")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Locker")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Microwave")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherAmenities")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ParkingLot")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Refrigerator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SecuritySystem")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SwimmingPool")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Washer")
                        .HasColumnType("INTEGER");

                    b.HasKey("PropertyAmenitiesId");

                    b.HasIndex("PropertyId")
                        .IsUnique();

                    b.ToTable("PropertyAmenities");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.RentalRecord", b =>
                {
                    b.Property<int>("RentalRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractTerms")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DepositPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerCustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantCustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RentalRecordId");

                    b.HasIndex("OwnerCustomerId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("TenantCustomerId");

                    b.ToTable("RentalRecords");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.SalesRecord", b =>
                {
                    b.Property<int>("SalesRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuyerCustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContractTerms")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerCustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("SalesRecordId");

                    b.HasIndex("BuyerCustomerId");

                    b.HasIndex("OwnerCustomerId");

                    b.HasIndex("PropertyId");

                    b.ToTable("SalesRecords");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateAgencySystem.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Image", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Property", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Customer", "Owner")
                        .WithMany("OwnedProperties")
                        .HasForeignKey("OwnerCustomerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.PropertyAmenities", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Property", "Property")
                        .WithOne("PropertyAmenities")
                        .HasForeignKey("RealEstateAgencySystem.Models.PropertyAmenities", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.RentalRecord", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Customer", "OwnerCustomer")
                        .WithMany("RentalsAsOwner")
                        .HasForeignKey("OwnerCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateAgencySystem.Models.Property", "Property")
                        .WithMany("RentalRecords")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateAgencySystem.Models.Customer", "TenantCustomer")
                        .WithMany("RentalsAsTenant")
                        .HasForeignKey("TenantCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OwnerCustomer");

                    b.Navigation("Property");

                    b.Navigation("TenantCustomer");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.SalesRecord", b =>
                {
                    b.HasOne("RealEstateAgencySystem.Models.Customer", "BuyerCustomer")
                        .WithMany("SalesAsBuyer")
                        .HasForeignKey("BuyerCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateAgencySystem.Models.Customer", "OwnerCustomer")
                        .WithMany("SalesAsOwner")
                        .HasForeignKey("OwnerCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateAgencySystem.Models.Property", "Property")
                        .WithMany("SalesRecords")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BuyerCustomer");

                    b.Navigation("OwnerCustomer");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Customer", b =>
                {
                    b.Navigation("OwnedProperties");

                    b.Navigation("RentalsAsOwner");

                    b.Navigation("RentalsAsTenant");

                    b.Navigation("SalesAsBuyer");

                    b.Navigation("SalesAsOwner");
                });

            modelBuilder.Entity("RealEstateAgencySystem.Models.Property", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("PropertyAmenities")
                        .IsRequired();

                    b.Navigation("RentalRecords");

                    b.Navigation("SalesRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
