﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservaHoteles_TPFinal.Context;

#nullable disable

namespace ReservaHoteles_TPFinal.Migrations
{
    [DbContext(typeof(Hotel_context))]
    partial class Hotel_contextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReservaHoteles_TPFinal.Models.Habitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("capacidad")
                        .HasColumnType("int");

                    b.Property<double>("costoPorDia")
                        .HasColumnType("float");

                    b.Property<int>("numHabitacion")
                        .HasColumnType("int");

                    b.Property<bool>("ocupada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Habitaciones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            capacidad = 2,
                            costoPorDia = 6500.0,
                            numHabitacion = 11,
                            ocupada = true
                        },
                        new
                        {
                            Id = 2,
                            capacidad = 5,
                            costoPorDia = 8000.0,
                            numHabitacion = 12,
                            ocupada = false
                        },
                        new
                        {
                            Id = 3,
                            capacidad = 3,
                            costoPorDia = 6500.0,
                            numHabitacion = 13,
                            ocupada = false
                        },
                        new
                        {
                            Id = 4,
                            capacidad = 2,
                            costoPorDia = 6000.0,
                            numHabitacion = 14,
                            ocupada = false
                        });
                });

            modelBuilder.Entity("ReservaHoteles_TPFinal.Models.Huesped", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("nroHabitacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("ReservaHoteles_TPFinal.Models.MedioDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("MediosDePago");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            nombre = "Credito"
                        },
                        new
                        {
                            Id = 2,
                            nombre = "Debito"
                        },
                        new
                        {
                            Id = 3,
                            nombre = "Mercado Pagp"
                        },
                        new
                        {
                            Id = 4,
                            nombre = "Trsnaferencia"
                        },
                        new
                        {
                            Id = 5,
                            nombre = "Efectivo"
                        });
                });

            modelBuilder.Entity("ReservaHoteles_TPFinal.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("fechaEgreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("idMedioPago")
                        .HasColumnType("int");

                    b.Property<int>("nroHabitacion")
                        .HasColumnType("int");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.Property<string>("titular")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
