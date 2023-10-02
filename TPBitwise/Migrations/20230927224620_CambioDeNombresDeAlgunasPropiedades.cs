using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPBitwise.Migrations
{
    /// <inheritdoc />
    public partial class CambioDeNombresDeAlgunasPropiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tareas",
                newName: "TareaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Proyectos",
                newName: "ProyectoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Etiquetas",
                newName: "EtiquetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TareaId",
                table: "Tareas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProyectoId",
                table: "Proyectos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EtiquetaId",
                table: "Etiquetas",
                newName: "Id");
        }
    }
}
