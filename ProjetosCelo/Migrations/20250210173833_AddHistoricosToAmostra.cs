using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetosCelo.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoricosToAmostra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amostras_AspNetUsers_CriadorId",
                table: "Amostras");

            migrationBuilder.DropForeignKey(
                name: "FK_Amostras_AspNetUsers_ResponsavelId",
                table: "Amostras");

            migrationBuilder.DropIndex(
                name: "IX_Amostras_CriadorId",
                table: "Amostras");

            migrationBuilder.DropIndex(
                name: "IX_Amostras_ResponsavelId",
                table: "Amostras");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Amostras");

            migrationBuilder.RenameColumn(
                name: "ResponsavelId",
                table: "Amostras",
                newName: "ResponsavelNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponsavelNome",
                table: "Amostras",
                newName: "ResponsavelId");

            migrationBuilder.AddColumn<string>(
                name: "CriadorId",
                table: "Amostras",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Amostras_CriadorId",
                table: "Amostras",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Amostras_ResponsavelId",
                table: "Amostras",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amostras_AspNetUsers_CriadorId",
                table: "Amostras",
                column: "CriadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amostras_AspNetUsers_ResponsavelId",
                table: "Amostras",
                column: "ResponsavelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
