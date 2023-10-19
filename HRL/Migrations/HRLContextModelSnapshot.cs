﻿// <auto-generated />
using System;
using HRL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRL.Migrations
{
    [DbContext(typeof(HRLContext))]
    partial class HRLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRL.Database.FromPlc.AllgemeinVonSps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Kommunikation")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AllgemeinesVonSps");
                });

            modelBuilder.Entity("HRL.Database.FromPlc.FehlerlisteVonSps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktiv")
                        .HasColumnType("bit");

                    b.Property<string>("Beschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumUhrzeit")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FehlerlistenVonSps");
                });

            modelBuilder.Entity("HRL.Database.FromPlc.TransportmaschineVonSps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BelegungPhysisch")
                        .HasColumnType("bit");

                    b.Property<float>("IstPositionX")
                        .HasColumnType("real");

                    b.Property<int>("IstPositionXP")
                        .HasColumnType("int");

                    b.Property<float>("IstPositionY")
                        .HasColumnType("real");

                    b.Property<int>("IstPositionYP")
                        .HasColumnType("int");

                    b.Property<float>("IstPositionZ")
                        .HasColumnType("real");

                    b.Property<int>("IstPositionZP")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SollPositionX")
                        .HasColumnType("real");

                    b.Property<int>("SollPositionXP")
                        .HasColumnType("int");

                    b.Property<float>("SollPositionY")
                        .HasColumnType("real");

                    b.Property<int>("SollPositionYP")
                        .HasColumnType("int");

                    b.Property<float>("SollPositionZ")
                        .HasColumnType("real");

                    b.Property<int>("SollPositionZP")
                        .HasColumnType("int");

                    b.Property<int>("Zustand")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TransportmaschinenVonSps");
                });

            modelBuilder.Entity("HRL.Database.Local.FehlerLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumUhrzeit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Meldung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FehlerLogs");
                });

            modelBuilder.Entity("HRL.Database.Local.Jobs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Art")
                        .HasColumnType("smallint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Gewicht")
                        .HasColumnType("real");

                    b.Property<short>("LagerId")
                        .HasColumnType("smallint");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<short>("PositionXP")
                        .HasColumnType("smallint");

                    b.Property<short>("PositionYP")
                        .HasColumnType("smallint");

                    b.Property<short>("PositionZP")
                        .HasColumnType("smallint");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransportDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("HRL.Database.StockSpace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostingUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransportDateTime")
                        .HasColumnType("datetime2");

                    b.Property<short>("TransportId")
                        .HasColumnType("smallint");

                    b.Property<string>("TransportUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("StockSpaces");
                });

            modelBuilder.Entity("HRL.Database.ToPlc.AllgemeinAnSps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("StoerungQuittieren")
                        .HasColumnType("bit");

                    b.Property<bool>("WatchDog")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AllgemeinesAnSps");
                });

            modelBuilder.Entity("HRL.Database.ToPlc.AuftragAnSps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Art")
                        .HasColumnType("smallint");

                    b.Property<float>("Gewicht")
                        .HasColumnType("real");

                    b.Property<short>("LagerId")
                        .HasColumnType("smallint");

                    b.Property<short>("PositionXP")
                        .HasColumnType("smallint");

                    b.Property<short>("PositionYP")
                        .HasColumnType("smallint");

                    b.Property<short>("PositionZP")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("AuftragAnSps");
                });
#pragma warning restore 612, 618
        }
    }
}
