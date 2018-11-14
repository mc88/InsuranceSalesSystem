﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PolicyService.Bo.Infrastructure.Database;

namespace PolicyService.Bo.Infrastructure.Database.Migrations
{
    [DbContext(typeof(PolicyDbContext))]
    [Migration("20181112165558_CreatePolicyDB")]
    partial class CreatePolicyDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PolicyService.Bo.Domain.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OfferNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("OfferStatus")
                        .HasMaxLength(25);

                    b.Property<DateTime>("PolicyFrom");

                    b.Property<int?>("PolicyHolderId");

                    b.Property<DateTime>("PolicyTo");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<decimal>("TotalPrice");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("PolicyHolderId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.OfferCover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverCode")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("CoverFrom");

                    b.Property<DateTime>("CoverTo");

                    b.Property<int?>("OfferId");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("OfferCover");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.PolicyCover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverCode")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("CoverFrom");

                    b.Property<DateTime>("CoverTo");

                    b.Property<int?>("PolicyVersionId");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("PolicyVersionId");

                    b.ToTable("PolicyCover");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.PolicyHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("PolicyHolder");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.PolicyVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("PolicyFrom");

                    b.Property<int?>("PolicyHolderId");

                    b.Property<int?>("PolicyId");

                    b.Property<int>("PolicyStatus")
                        .HasMaxLength(25);

                    b.Property<DateTime>("PolicyTo");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<decimal>("TotalPremium");

                    b.Property<DateTime>("VersionFrom");

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("VersionTo");

                    b.HasKey("Id");

                    b.HasIndex("PolicyHolderId");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyVersion");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.Offer", b =>
                {
                    b.HasOne("PolicyService.Bo.Domain.PolicyHolder", "PolicyHolder")
                        .WithMany()
                        .HasForeignKey("PolicyHolderId");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.OfferCover", b =>
                {
                    b.HasOne("PolicyService.Bo.Domain.Offer")
                        .WithMany("Covers")
                        .HasForeignKey("OfferId");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.PolicyCover", b =>
                {
                    b.HasOne("PolicyService.Bo.Domain.PolicyVersion")
                        .WithMany("Covers")
                        .HasForeignKey("PolicyVersionId");
                });

            modelBuilder.Entity("PolicyService.Bo.Domain.PolicyVersion", b =>
                {
                    b.HasOne("PolicyService.Bo.Domain.PolicyHolder", "PolicyHolder")
                        .WithMany()
                        .HasForeignKey("PolicyHolderId");

                    b.HasOne("PolicyService.Bo.Domain.Policy", "Policy")
                        .WithMany("PolicyVersions")
                        .HasForeignKey("PolicyId");
                });
#pragma warning restore 612, 618
        }
    }
}
