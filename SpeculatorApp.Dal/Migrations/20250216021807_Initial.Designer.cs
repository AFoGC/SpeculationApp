﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeculationApp.Dal.Context;

#nullable disable

namespace SpeculationApp.Dal.Migrations
{
    [DbContext(typeof(TradingContext))]
    [Migration("20250216021807_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Convertation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<decimal>("BaseCurrencyAmount")
                        .HasColumnType("TEXT")
                        .HasColumnName("BaseCurrencyAmount");

                    b.Property<int>("BaseCurrencyId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("BaseCurrencyId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ToTradeCurrency")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TradeCurrencyAmount")
                        .HasColumnType("TEXT")
                        .HasColumnName("TradeCurrencyAmount");

                    b.Property<int>("TradeCurrencyId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TradeCurrencyId");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId", "TradeCurrencyId");

                    b.ToTable("Convertations");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT")
                        .HasColumnName("Amount");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CurrencyId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("Date");

                    b.Property<int>("OperationTypeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("OperationTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("OperationTypeId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.OperationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<bool>("IsIncrease")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsIncrease");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("OperationTypes");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Pair", b =>
                {
                    b.Property<int>("BaseCurrencyId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("BaseCurrencyId");

                    b.Property<int>("TradeCurrencyId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TradeCurrencyId");

                    b.Property<int>("PositionInList")
                        .HasColumnType("INTEGER")
                        .HasColumnName("PositionInList");

                    b.HasKey("BaseCurrencyId", "TradeCurrencyId");

                    b.HasIndex("TradeCurrencyId");

                    b.ToTable("Pairs");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Convertation", b =>
                {
                    b.HasOne("SpeculationApp.Dal.Entities.Pair", "Pair")
                        .WithMany("Convertations")
                        .HasForeignKey("BaseCurrencyId", "TradeCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pair");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Operation", b =>
                {
                    b.HasOne("SpeculationApp.Dal.Entities.Currency", "Currency")
                        .WithMany("Operations")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeculationApp.Dal.Entities.OperationType", "OperationType")
                        .WithMany("Operations")
                        .HasForeignKey("OperationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("OperationType");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Pair", b =>
                {
                    b.HasOne("SpeculationApp.Dal.Entities.Currency", "BaseCurrency")
                        .WithMany("PairsAsBaseCurrency")
                        .HasForeignKey("BaseCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeculationApp.Dal.Entities.Currency", "TradeCurrency")
                        .WithMany("PairsAsTradeCurrency")
                        .HasForeignKey("TradeCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseCurrency");

                    b.Navigation("TradeCurrency");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Currency", b =>
                {
                    b.Navigation("Operations");

                    b.Navigation("PairsAsBaseCurrency");

                    b.Navigation("PairsAsTradeCurrency");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.OperationType", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("SpeculationApp.Dal.Entities.Pair", b =>
                {
                    b.Navigation("Convertations");
                });
#pragma warning restore 612, 618
        }
    }
}
