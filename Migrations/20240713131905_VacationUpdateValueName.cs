using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrWebApp.Migrations
{
    /// <inheritdoc />
    public partial class VacationUpdateValueName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDay",
                table: "Vacations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndDay",
                table: "Vacations",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Vacations",
                newName: "StartDay");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Vacations",
                newName: "EndDay");
        }
    }
}
