using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D8M7Q2_SportEvents.Data.Migrations
{
    /// <inheritdoc />
    public partial class SportEvent_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SportEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "SportEvents");
        }
    }
}
