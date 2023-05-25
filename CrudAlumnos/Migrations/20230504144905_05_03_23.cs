using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudAlumnos.Migrations
{
    /// <inheritdoc />
    public partial class _05_03_23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Grado_GradoId",
                table: "Alumno");

            migrationBuilder.DropTable(
                name: "Grado");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_GradoId",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Alumno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado_Alumno = table.Column<bool>(type: "bit", nullable: false),
                    Grado_Escolar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.Id);
                });

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
    }
}
