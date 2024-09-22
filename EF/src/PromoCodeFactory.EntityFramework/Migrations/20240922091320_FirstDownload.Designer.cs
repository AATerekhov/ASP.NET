﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromoCodeFactory.EntityFramework;

#nullable disable

namespace PromoCodeFactory.EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240922091320_FirstDownload")]
    partial class FirstDownload
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.Administration.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AppliedPromocodesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.Administration.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.CustomerPreference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CudtomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PreferenceId");

                    b.ToTable("CustomerPreferences");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Prefirences");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.PromoCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BiginDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartnerName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceInfo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PreferenceId");

                    b.ToTable("PromoCodes");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.Administration.Employee", b =>
                {
                    b.HasOne("PromoCodeFactory.Core.Domain.Administration.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.CustomerPreference", b =>
                {
                    b.HasOne("PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", "Customer")
                        .WithMany("Preferences")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", "Preference")
                        .WithMany("Customers")
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.PromoCode", b =>
                {
                    b.HasOne("PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", "Owner")
                        .WithMany("PromoCodes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PromoCodeFactory.Core.Domain.Administration.Employee", "PartnerManager")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", "Preference")
                        .WithMany("PromoCodes")
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("PartnerManager");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.Administration.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", b =>
                {
                    b.Navigation("Preferences");

                    b.Navigation("PromoCodes");
                });

            modelBuilder.Entity("PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("PromoCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
