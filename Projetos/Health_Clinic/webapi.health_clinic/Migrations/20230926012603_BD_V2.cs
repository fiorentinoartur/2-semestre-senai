using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdTipoDeUsuario",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoDeUsuario",
                table: "Usuario",
                column: "IdTipoDeUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TiposDeUsuario_IdTipoDeUsuario",
                table: "Usuario",
                column: "IdTipoDeUsuario",
                principalTable: "TiposDeUsuario",
                principalColumn: "IdTiposDeUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TiposDeUsuario_IdTipoDeUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdTipoDeUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdTipoDeUsuario",
                table: "Usuario");
        }
    }
}
