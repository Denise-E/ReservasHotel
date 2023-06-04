using Microsoft.EntityFrameworkCore;
using ReservaHoteles_TPFinal.Models;

namespace ReservaHoteles_TPFinal.Context
{
    public class Hotel_context: DbContext
    {
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Huesped> Huespedes { get; set; }
        public DbSet<MedioDePago> MediosDePago { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-BKKMKDA\\MSSQLSERVER01 ; Initial Catalog = Hotel_PNT; Integrated Security = true; Encrypt=true; TrustServerCertificate=true");
        }
    }
}
