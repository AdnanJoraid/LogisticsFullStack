﻿// <auto-generated />
using System;
using Backend.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220108181704_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Backend.Models.InventoryItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("BeginningQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Backend.Models.InventoryTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("InventoryItemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ItemLocationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("WarehouseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemId");

                    b.HasIndex("ItemLocationId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Backend.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Aisle")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Shelf")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Backend.Models.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Backend.Models.InventoryTransaction", b =>
                {
                    b.HasOne("Backend.Models.InventoryItem", "InventoryItem")
                        .WithMany()
                        .HasForeignKey("InventoryItemId");

                    b.HasOne("Backend.Models.Location", "ItemLocation")
                        .WithMany()
                        .HasForeignKey("ItemLocationId");

                    b.HasOne("Backend.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId");

                    b.Navigation("InventoryItem");

                    b.Navigation("ItemLocation");

                    b.Navigation("Warehouse");
                });
#pragma warning restore 612, 618
        }
    }
}
