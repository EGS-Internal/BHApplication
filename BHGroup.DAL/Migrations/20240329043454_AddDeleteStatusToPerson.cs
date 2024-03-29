using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHGroup.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteStatusToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deleteStatus",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deleteStatus",
                table: "lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleteStatus",
                table: "students");

            migrationBuilder.DropColumn(
                name: "deleteStatus",
                table: "lecturers");
        }
    }
}
