using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem_web_api.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationIdGeneration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Reservations",
                schema: "Booking",
                newName: "Reservations",
                newSchema: "booking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Booking");

            migrationBuilder.RenameTable(
                name: "Reservations",
                schema: "booking",
                newName: "Reservations",
                newSchema: "Booking");
        }
    }
}
