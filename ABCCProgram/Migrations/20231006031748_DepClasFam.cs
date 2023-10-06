using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCCProgram.Migrations
{
    public partial class DepClasFam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClase = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFamilia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Familias");

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
        }
    }
}
