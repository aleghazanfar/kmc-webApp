﻿// <auto-generated />
using System;
using KMCAA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KMCAA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240216110912_AddMemberTable")]
    partial class AddMemberTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KMCAA.Models.LookUp", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("LookUpTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LookUps");
                });

            modelBuilder.Entity("KMCAA.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClinicNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraduationFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberResideIn")
                        .HasColumnType("int");

                    b.Property<int?>("MembershipTypeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PermanentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresendWorkPlance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfGraduation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
