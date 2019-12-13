﻿// <auto-generated />
using System;
using ExampleDataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ExampleDataLibrary.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    [Migration("20191202052344_ExampleMigration")]
    partial class ExampleMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ExampleEntityLibrary.Kullanıcı", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("AsılŞifre")
                        .HasColumnType("text");

                    b.Property<string>("EPostaAdres")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Girişİsim")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("KaldırmaSebebi")
                        .HasColumnType("text");

                    b.Property<string>("KarmaŞifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobilNumara")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("OluşturuKimsiId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Oluşturulduğunda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Pozisyon")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("SonGirişTarihVeZaman")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Kullanıcılar");
                });

            modelBuilder.Entity("ExampleEntityLibrary.YerAdres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Betimleme")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("BinaNumerası")
                        .HasColumnType("character varying(7)")
                        .HasMaxLength(7);

                    b.Property<float?>("Boylam")
                        .HasColumnType("real");

                    b.Property<string>("CaddeSokakAdı")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<float?>("Enlem")
                        .HasColumnType("real");

                    b.Property<string>("GoogleMapsUrl")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("KöyId")
                        .HasColumnType("integer");

                    b.Property<int?>("MahalleId")
                        .HasColumnType("integer");

                    b.Property<string>("Notlar")
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<int>("OluşturuKimsiId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Oluşturulduğunda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("SemtId")
                        .HasColumnType("integer");

                    b.Property<int>("ÜlkeId")
                        .HasColumnType("integer");

                    b.Property<int?>("İlId")
                        .HasColumnType("integer");

                    b.Property<int?>("İlçeId")
                        .HasColumnType("integer");

                    b.Property<int>("ŞehirId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("YerAdresler");
                });

            modelBuilder.Entity("ExampleEntityLibrary.ÇalışmaZamanlama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HaftaGün")
                        .HasColumnType("integer");

                    b.Property<int>("OluşturuKimsiId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Oluşturulduğunda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Saate")
                        .IsRequired()
                        .HasColumnType("character varying(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Saatten")
                        .IsRequired()
                        .HasColumnType("character varying(5)")
                        .HasMaxLength(5);

                    b.Property<int>("İşletmeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ÇalışmaZamanlamalar");
                });
#pragma warning restore 612, 618
        }
    }
}
