﻿// <auto-generated />
using System;
using HW_6.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW_6.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230507103310_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HW_6.Models.Analysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("an_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("an_cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(124)
                        .HasColumnType("nvarchar(124)")
                        .HasColumnName("an_name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("an_price");

                    b.Property<int>("an_group")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("an_group");

                    b.ToTable("Analysis");
                });

            modelBuilder.Entity("HW_6.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("gr_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(124)
                        .HasColumnType("nvarchar(124)")
                        .HasColumnName("gr_name");

                    b.Property<int>("Temp")
                        .HasColumnType("int")
                        .HasColumnName("gr_temp");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("HW_6.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ord_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrdDatetime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ord_datetime");

                    b.Property<int>("ord_an")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ord_an");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HW_6.Models.Analysis", b =>
                {
                    b.HasOne("HW_6.Models.Group", "AnGroup")
                        .WithMany()
                        .HasForeignKey("an_group")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnGroup");
                });

            modelBuilder.Entity("HW_6.Models.Order", b =>
                {
                    b.HasOne("HW_6.Models.Analysis", "OrdAnalysis")
                        .WithMany("Orders")
                        .HasForeignKey("ord_an")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("OrdAnalysis");
                });

            modelBuilder.Entity("HW_6.Models.Analysis", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}