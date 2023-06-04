using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaHoteles_TPFinal.Migrations
{
    /// <inheritdoc />
    public partial class mig_inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numHabitacion = table.Column<int>(type: "int", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    costoPorDia = table.Column<double>(type: "float", nullable: false),
                    ocupada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nroHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediosDePago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosDePago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nroHabitacion = table.Column<int>(type: "int", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    idMedioPago = table.Column<int>(type: "int", nullable: false),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "MediosDePago");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
