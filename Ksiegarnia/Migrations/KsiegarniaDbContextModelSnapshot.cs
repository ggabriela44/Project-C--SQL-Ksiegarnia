﻿// <auto-generated />
using System;
using Ksiegarnia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ksiegarnia.Migrations
{
    [DbContext(typeof(KsiegarniaDbContext))]
    partial class KsiegarniaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ksiegarnia.Models.Dostawa", b =>
                {
                    b.Property<int>("Id_dostawa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_dostawa"), 1L, 1);

                    b.Property<float>("Oplata")
                        .HasColumnType("real");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_dostawa");

                    b.ToTable("Dostawa");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Gatunek", b =>
                {
                    b.Property<int>("Id_gatunek")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_gatunek"), 1L, 1);

                    b.Property<int>("Gatunek_ksiazki")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id_gatunek");

                    b.ToTable("Gatunek");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Klient", b =>
                {
                    b.Property<int>("Id_klient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_klient"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nr_telefon")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id_klient");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Ksiazka", b =>
                {
                    b.Property<int>("Id_ksiazka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_ksiazka"), 1L, 1);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<DateTime>("Data_wydania")
                        .HasColumnType("datetime2");

                    b.Property<int>("GatunekID")
                        .HasColumnType("int");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wydawnictwo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_ksiazka");

                    b.HasIndex("GatunekID");

                    b.ToTable("Ksiazka");
                });

            modelBuilder.Entity("Ksiegarnia.Models.KsiazkaZamowienie", b =>
                {
                    b.Property<int>("KsiazkaID")
                        .HasColumnType("int");

                    b.Property<int>("ZamowienieID")
                        .HasColumnType("int");

                    b.HasKey("KsiazkaID", "ZamowienieID");

                    b.HasIndex("ZamowienieID");

                    b.ToTable("KsiazkaZamowienie");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Zamowienie", b =>
                {
                    b.Property<int>("Id_zamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_zamowienia"), 1L, 1);

                    b.Property<float>("Cena_dostawy")
                        .HasColumnType("real");

                    b.Property<float>("Cena_ksiazek")
                        .HasColumnType("real");

                    b.Property<int>("DostawaID")
                        .HasColumnType("int");

                    b.Property<int>("KlientID")
                        .HasColumnType("int");

                    b.Property<string>("Kod_pocztowy")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Miejscowosc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nr_domu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Typ_zaplaty")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_zamowienia");

                    b.HasIndex("DostawaID");

                    b.HasIndex("KlientID");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Ksiazka", b =>
                {
                    b.HasOne("Ksiegarnia.Models.Gatunek", "Gatunek")
                        .WithMany("Ksiazka")
                        .HasForeignKey("GatunekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gatunek");
                });

            modelBuilder.Entity("Ksiegarnia.Models.KsiazkaZamowienie", b =>
                {
                    b.HasOne("Ksiegarnia.Models.Ksiazka", "Ksiazka")
                        .WithMany("KsiazkiZamowione")
                        .HasForeignKey("KsiazkaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ksiegarnia.Models.Zamowienie", "Zamowienie")
                        .WithMany("KsiazkaZamowione")
                        .HasForeignKey("ZamowienieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ksiazka");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Zamowienie", b =>
                {
                    b.HasOne("Ksiegarnia.Models.Dostawa", "Dostawa")
                        .WithMany("Zamowienia")
                        .HasForeignKey("DostawaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ksiegarnia.Models.Klient", "Klient")
                        .WithMany("Zamowienia")
                        .HasForeignKey("KlientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dostawa");

                    b.Navigation("Klient");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Dostawa", b =>
                {
                    b.Navigation("Zamowienia");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Gatunek", b =>
                {
                    b.Navigation("Ksiazka");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Klient", b =>
                {
                    b.Navigation("Zamowienia");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Ksiazka", b =>
                {
                    b.Navigation("KsiazkiZamowione");
                });

            modelBuilder.Entity("Ksiegarnia.Models.Zamowienie", b =>
                {
                    b.Navigation("KsiazkaZamowione");
                });
#pragma warning restore 612, 618
        }
    }
}
