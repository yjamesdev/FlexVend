using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "DataUpdate",
                table: "Companies",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "DataUpdate",
                table: "Branches",
                newName: "DateUpdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "Companies",
                newName: "DataUpdate");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "Branches",
                newName: "DataUpdate");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
