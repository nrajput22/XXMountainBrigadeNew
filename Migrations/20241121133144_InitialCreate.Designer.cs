﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XXMountainBrigadeNew.Models;

#nullable disable

namespace XXMountainBrigadeNew.Migrations
{
    [DbContext(typeof(MBDbContext))]
    [Migration("20241121133144_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Xml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKey");
                });

            modelBuilder.Entity("XXMountainBrigadeNew.Models.Company", b =>
                {
                    b.Property<int>("CoyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoyId"));

                    b.Property<string>("CoyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("XXMountainBrigadeNew.Models.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoyId")
                        .HasColumnType("int");

                    b.Property<int?>("CoyNameCoyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PermanentAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PersId")
                        .HasColumnType("int");

                    b.Property<int>("PersNo")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("PersonnelNumber");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<int?>("RankNameRankId")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfPersonnel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CoyId");

                    b.HasIndex("CoyNameCoyId");

                    b.HasIndex("RankId");

                    b.HasIndex("RankNameRankId");

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("XXMountainBrigadeNew.Models.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankId"));

                    b.Property<string>("RankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seniority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RankId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("XXMountainBrigadeNew.Models.Usertbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("UsersTbl");
                });

            modelBuilder.Entity("XXMountainBrigadeNew.Models.Personnel", b =>
                {
                    b.HasOne("XXMountainBrigadeNew.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CoyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XXMountainBrigadeNew.Models.Company", "CoyName")
                        .WithMany()
                        .HasForeignKey("CoyNameCoyId");

                    b.HasOne("XXMountainBrigadeNew.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XXMountainBrigadeNew.Models.Rank", "RankName")
                        .WithMany()
                        .HasForeignKey("RankNameRankId");

                    b.Navigation("Company");

                    b.Navigation("CoyName");

                    b.Navigation("Rank");

                    b.Navigation("RankName");
                });
#pragma warning restore 612, 618
        }
    }
}
