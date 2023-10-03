using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using webapi.health_clinic.Domains;

#nullable disable

namespace webapi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class CriarGatilhoExclusaoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
   CREATE TRIGGER DeleteConsultasOnDeleteMedico
ON Medico
AFTER DELETE
AS
BEGIN
    -- Exclua as consultas relacionadas ao médico excluído
    DELETE FROM Consulta
    WHERE IdMedico IN(SELECT IdMedico FROM DELETED);
            END;
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
