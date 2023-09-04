using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCovid.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    IdSolicitante = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Perfil = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.IdSolicitante);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    IdRelatorio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RJ_Datadaaplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    QtdeVacinados = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IdSolicitante = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.IdRelatorio);
                    table.ForeignKey(
                        name: "FK_Relatorio_Solicitante_IdSolicitante",
                        column: x => x.IdSolicitante,
                        principalTable: "Solicitante",
                        principalColumn: "IdSolicitante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_IdSolicitante",
                table: "Relatorio",
                column: "IdSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitante_CPF",
                table: "Solicitante",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitante_Nome",
                table: "Solicitante",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Solicitante");
        }
    }
}
