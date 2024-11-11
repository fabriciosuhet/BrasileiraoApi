using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasileiraoApi.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titulos_Jogadores_JogadorId",
                table: "Titulos");

            migrationBuilder.AlterColumn<int>(
                name: "JogadorId",
                table: "Titulos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Titulos_Jogadores_JogadorId",
                table: "Titulos",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titulos_Jogadores_JogadorId",
                table: "Titulos");

            migrationBuilder.AlterColumn<int>(
                name: "JogadorId",
                table: "Titulos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Titulos_Jogadores_JogadorId",
                table: "Titulos",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id");
        }
    }
}
