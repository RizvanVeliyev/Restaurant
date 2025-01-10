using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhoneNumberConfigFromReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Contact_PhoneNumber",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Contact_PhoneNumber",
                table: "Reservations",
                sql: "PhoneNumber LIKE '+%' AND LEN(PhoneNumber) >= 10 AND LEN(PhoneNumber) <= 15");
        }
    }
}
