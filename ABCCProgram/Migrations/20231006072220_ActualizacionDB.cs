using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCCProgram.Migrations
{
    public partial class ActualizacionDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Clases_ClaseTabId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Departamentos_DepartamentoTabId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Familias_FamiliaTabId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ClaseTabId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_DepartamentoTabId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_FamiliaTabId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ClaseTabId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "DepartamentoTabId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "FamiliaTabId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Familia",
                table: "Productos",
                newName: "FamiliaId");

            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "Productos",
                newName: "DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "Clase",
                table: "Productos",
                newName: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ClaseId",
                table: "Productos",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DepartamentoId",
                table: "Productos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FamiliaId",
                table: "Productos",
                column: "FamiliaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Clases_ClaseId",
                table: "Productos",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Departamentos_DepartamentoId",
                table: "Productos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Familias_FamiliaId",
                table: "Productos",
                column: "FamiliaId",
                principalTable: "Familias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Clases_ClaseId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Departamentos_DepartamentoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Familias_FamiliaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ClaseId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_DepartamentoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_FamiliaId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "FamiliaId",
                table: "Productos",
                newName: "Familia");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Productos",
                newName: "Departamento");

            migrationBuilder.RenameColumn(
                name: "ClaseId",
                table: "Productos",
                newName: "Clase");

            migrationBuilder.AddColumn<int>(
                name: "ClaseTabId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoTabId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamiliaTabId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ClaseTabId",
                table: "Productos",
                column: "ClaseTabId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DepartamentoTabId",
                table: "Productos",
                column: "DepartamentoTabId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FamiliaTabId",
                table: "Productos",
                column: "FamiliaTabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Clases_ClaseTabId",
                table: "Productos",
                column: "ClaseTabId",
                principalTable: "Clases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Departamentos_DepartamentoTabId",
                table: "Productos",
                column: "DepartamentoTabId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Familias_FamiliaTabId",
                table: "Productos",
                column: "FamiliaTabId",
                principalTable: "Familias",
                principalColumn: "Id");
        }
    }
}
