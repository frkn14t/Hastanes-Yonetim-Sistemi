﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneBolu.Migrations
{
    [DbContext(typeof(HastaneBoluDBContext))]
    [Migration("20241213201214_InitialCreate")]
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

            modelBuilder.Entity("TurkHastanesi.Models.Classes.AcilDurum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AcilDurumlar");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AsistanId")
                        .HasColumnType("int");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<string>("Not")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RandevuTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AsistanId");

                    b.HasIndex("DoktorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Asistan", b =>
                {
                    b.Property<int>("AsistanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsistanId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsistanId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("KullaniciId")
                        .IsUnique();

                    b.ToTable("Asistanlar");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("HastaSayisi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Doktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoktorId");

                    b.HasIndex("KullaniciId")
                        .IsUnique();

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciId");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Nobet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AsistanId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AsistanId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Nobetler");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RolAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Appointment", b =>
                {
                    b.HasOne("TurkHastanesi.Models.Classes.Asistan", "Asistan")
                        .WithMany("Appointments")
                        .HasForeignKey("AsistanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TurkHastanesi.Models.Classes.Doktor", "doktor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asistan");

                    b.Navigation("doktor");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Asistan", b =>
                {
                    b.HasOne("TurkHastanesi.Models.Classes.Department", "Department")
                        .WithMany("Asistanlar")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TurkHastanesi.Models.Classes.Kullanici", "Kullanici")
                        .WithOne()
                        .HasForeignKey("TurkHastanesi.Models.Classes.Asistan", "KullaniciId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Department", b =>
                {
                    b.HasOne("TurkHastanesi.Models.Classes.Doktor", "Doktor")
                        .WithMany("Departments")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Doktor", b =>
                {
                    b.HasOne("TurkHastanesi.Models.Classes.Kullanici", "kullanici")
                        .WithOne()
                        .HasForeignKey("TurkHastanesi.Models.Classes.Doktor", "KullaniciId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("kullanici");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Kullanici", b =>
                {
                    b.HasOne("TurkHastanesi.Models.Classes.Rol", "Rol")
                        .WithMany("Kullanicilar")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Nobet", b =>
                {
                    b.HasOne("TurkHastanesi.Models.Classes.Asistan", "Asistan")
                        .WithMany("Nobetler")
                        .HasForeignKey("AsistanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TurkHastanesi.Models.Classes.Department", "Department")
                        .WithMany("Nobetler")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asistan");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Asistan", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Nobetler");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Department", b =>
                {
                    b.Navigation("Asistanlar");

                    b.Navigation("Nobetler");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Doktor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("TurkHastanesi.Models.Classes.Rol", b =>
                {
                    b.Navigation("Kullanicilar");
                });
#pragma warning restore 612, 618
        }
    }
}
