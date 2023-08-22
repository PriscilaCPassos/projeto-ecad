using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMusical.Migrations
{
    public partial class RelacionamentoTitularObra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitularId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_TitularId",
                table: "Obras",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Titulares_TitularId",
                table: "Obras",
                column: "TitularId",
                principalTable: "Titulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Titulares_TitularId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_TitularId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "TitularId",
                table: "Obras");
        }
    }
}
