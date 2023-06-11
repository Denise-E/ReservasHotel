using Microsoft.EntityFrameworkCore;
using ReservaHoteles_TPFinal.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservaHoteles_TPFinal.Context
{
    public class Hotel_context: DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Habitacion>().HasData(
                new Habitacion()
                {
                    Id = 1,
                    numHabitacion = 11,
                    capacidad = 2,
                    costoPorDia = 6500,
                    ocupada = true
                },

                new Habitacion()
                {
                    Id = 2,
                    numHabitacion = 12,
                    capacidad = 5,
                    costoPorDia = 8000,
                    ocupada = false
                },

                new Habitacion()
                {
                    Id = 3,
                    numHabitacion = 13,
                    capacidad = 3,
                    costoPorDia = 6500,
                    ocupada = false
                },

                new Habitacion()
                {
                    Id = 4,
                    numHabitacion = 14,
                    capacidad = 2,
                    costoPorDia = 6000,
                    ocupada = false
                }
             );

            builder.Entity<MedioDePago>().HasData(
                new MedioDePago()
                {
                    Id = 1,
                    nombre = "Credito",
                },

                new MedioDePago()
                {
                    Id=2,
                    nombre = "Debito"
                },

                new MedioDePago()
                {
                    Id = 3,
                    nombre = "Mercado Pagp"
                },

                new MedioDePago()
                {
                    Id = 4,
                    nombre = "Trsnaferencia"
                },

                new MedioDePago()
                {
                    Id = 5,
                    nombre = "Efectivo"
                }
            );
        }

        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Huesped> Huespedes { get; set; }
        public DbSet<MedioDePago> MediosDePago { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            //La de arriba de todo es la de Denu, me dejo la mia abajo comentada
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-BKKMKDA\\MSSQLSERVER01 ; Initial Catalog = Hotel_PNT; Integrated Security = true; Encrypt=true; TrustServerCertificate=true");
            //Ivan:
            //optionsBuilder.UseSqlServer("Data Source = LAPTOP-C56DTAB8\\MSSQLSERVER01 ; Initial Catalog = Hotel_PNT; Integrated Security = true; Encrypt=true; TrustServerCertificate=true");
        }
    }
}
