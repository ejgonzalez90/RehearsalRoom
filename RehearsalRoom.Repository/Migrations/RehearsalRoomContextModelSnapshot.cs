﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RehearsalRoom.Model;
using RehearsalRoom.Repository;
using System;

namespace RehearsalRoom.Repository.Migrations
{
    [DbContext(typeof(RehearsalRoomContext))]
    partial class RehearsalRoomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RehearsalRoom.Model.Band", b =>
                {
                    b.Property<int>("BandId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("BandId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("RehearsalRoom.Model.BandPlayer", b =>
                {
                    b.Property<int>("BandId");

                    b.Property<int>("PlayerId");

                    b.HasKey("BandId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("BandPlayer");
                });

            modelBuilder.Entity("RehearsalRoom.Model.BrandModel", b =>
                {
                    b.Property<int>("BrandModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstrumentBrandId");

                    b.Property<string>("Name");

                    b.HasKey("BrandModelId");

                    b.HasIndex("InstrumentBrandId");

                    b.ToTable("BrandModels");
                });

            modelBuilder.Entity("RehearsalRoom.Model.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<int>("BrandModelId");

                    b.Property<int?>("InstrumentBrandId");

                    b.Property<int?>("PlayerId");

                    b.Property<int?>("RoomId");

                    b.Property<int>("State");

                    b.HasKey("InstrumentId");

                    b.HasIndex("BrandModelId");

                    b.HasIndex("InstrumentBrandId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("RehearsalRoom.Model.InstrumentBrand", b =>
                {
                    b.Property<int>("InstrumentBrandId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandName");

                    b.HasKey("InstrumentBrandId");

                    b.ToTable("InstrumentBrands");
                });

            modelBuilder.Entity("RehearsalRoom.Model.Interval", b =>
                {
                    b.Property<int>("IntervalId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duration");

                    b.HasKey("IntervalId");

                    b.ToTable("Intervals");
                });

            modelBuilder.Entity("RehearsalRoom.Model.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("NickName");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RehearsalRoom.Model.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RehearsalRoom.Model.Turn", b =>
                {
                    b.Property<int>("TurnId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BandId");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int>("IntervalId");

                    b.Property<int>("RoomId");

                    b.HasKey("TurnId");

                    b.HasIndex("BandId");

                    b.HasIndex("IntervalId");

                    b.HasIndex("RoomId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("RehearsalRoom.Model.BandPlayer", b =>
                {
                    b.HasOne("RehearsalRoom.Model.Band", "Band")
                        .WithMany("BandPlayers")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RehearsalRoom.Model.Player", "Player")
                        .WithMany("PlayerBands")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RehearsalRoom.Model.BrandModel", b =>
                {
                    b.HasOne("RehearsalRoom.Model.InstrumentBrand", "BrandModelInstrumentBrand")
                        .WithMany()
                        .HasForeignKey("InstrumentBrandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RehearsalRoom.Model.Instrument", b =>
                {
                    b.HasOne("RehearsalRoom.Model.BrandModel", "InstrumentModel")
                        .WithMany()
                        .HasForeignKey("BrandModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RehearsalRoom.Model.InstrumentBrand", "InstrumentBrand")
                        .WithMany()
                        .HasForeignKey("InstrumentBrandId");

                    b.HasOne("RehearsalRoom.Model.Player")
                        .WithMany("PlayerInstruments")
                        .HasForeignKey("PlayerId");

                    b.HasOne("RehearsalRoom.Model.Room", "InstrumentCurrentRoom")
                        .WithMany("Instruments")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("RehearsalRoom.Model.Turn", b =>
                {
                    b.HasOne("RehearsalRoom.Model.Band", "TurnBand")
                        .WithMany("BandTurn")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RehearsalRoom.Model.Interval", "TurnInterval")
                        .WithMany()
                        .HasForeignKey("IntervalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RehearsalRoom.Model.Room", "TurnRoom")
                        .WithMany("Turns")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
