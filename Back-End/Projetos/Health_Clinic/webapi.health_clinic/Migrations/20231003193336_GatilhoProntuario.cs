using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class GatilhoProntuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
   CREATE TRIGGER DeleteProntuarioOnDeleteUsuario
ON Usuario
AFTER DELETE
AS
BEGIN
    -- Exclua as consultas relacionadas ao FeedBakcs excluído
    DELETE FROM Prontuario
    WHERE IdUsuario IN(SELECT IdUsuario FROM DELETED);
            END;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
