using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Prontuario_IdProntuario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdProntuario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdProntuario",
                table: "Consulta");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConsulta",
                table: "Prontuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_IdConsulta",
                table: "Prontuario",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuario_Consulta_IdConsulta",
                table: "Prontuario",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "IdConsulta",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prontuario_Consulta_IdConsulta",
                table: "Prontuario");

            migrationBuilder.DropIndex(
                name: "IX_Prontuario_IdConsulta",
                table: "Prontuario");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Prontuario");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProntuario",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdProntuario",
                table: "Consulta",
                column: "IdProntuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Prontuario_IdProntuario",
                table: "Consulta",
                column: "IdProntuario",
                principalTable: "Prontuario",
                principalColumn: "IdProntuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
