using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudAlumnos.Migrations
{
    /// <inheritdoc />
    public partial class _05_05_23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado_Alumno",
                table: "Alumno",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado_Alumno",
                table: "Alumno");
        }
    }
}
