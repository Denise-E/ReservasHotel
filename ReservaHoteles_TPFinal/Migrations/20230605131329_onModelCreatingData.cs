using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservaHoteles_TPFinal.Migrations
{
    /// <inheritdoc />
    public partial class onModelCreatingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "Id", "capacidad", "costoPorDia", "numHabitacion", "ocupada" },
                values: new object[,]
                {
                    { 1, 2, 6500.0, 11, true },
                    { 2, 5, 8000.0, 12, false },
                    { 3, 3, 6500.0, 13, false },
                    { 4, 2, 6000.0, 14, false }
                });

            migrationBuilder.InsertData(
                table: "MediosDePago",
                columns: new[] { "Id", "nombre" },
                values: new object[,]
                {
                    { 1, "Credito" },
                    { 2, "Debito" },
                    { 3, "Mercado Pagp" },
                    { 4, "Trsnaferencia" },
                    { 5, "Efectivo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MediosDePago",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MediosDePago",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MediosDePago",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MediosDePago",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MediosDePago",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
