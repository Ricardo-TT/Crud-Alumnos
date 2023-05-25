using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudAlumnos.Migrations
{
    /// <inheritdoc />
    public partial class _08_05_23_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_GradoId",
                table: "Alumno",
                column: "GradoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Grado_GradoId",
                table: "Alumno",
                column: "GradoId",
                principalTable: "Grado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Grado_GradoId",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_GradoId",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Alumno");
        }
    }
}
