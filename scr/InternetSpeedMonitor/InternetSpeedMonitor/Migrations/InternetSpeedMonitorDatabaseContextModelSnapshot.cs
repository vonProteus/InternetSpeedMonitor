﻿// <auto-generated />
using System;
using InternetSpeedMonitor.DatabaseStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InternetSpeedMonitor.Migrations
{
    [DbContext(typeof(InternetSpeedMonitorDatabaseContext))]
    partial class InternetSpeedMonitorDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InternetSpeedMonitor.Data.SpeedResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Download")
                        .HasColumnType("integer");

                    b.Property<double>("Ping")
                        .HasColumnType("double precision");

                    b.Property<string>("RawJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Upload")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Timestamp");

                    b.ToTable("SpeedResults", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
