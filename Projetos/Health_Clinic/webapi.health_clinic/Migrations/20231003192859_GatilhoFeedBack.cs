using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class GatilhoFeedBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
   CREATE TRIGGER DeleteFeedBacksOnDeleteFeedBacks
ON FeedBacks
AFTER DELETE
AS
BEGIN
    -- Exclua as consultas relacionadas ao FeedBakcs excluído
    DELETE FROM FeedBacks
    WHERE IdFeedBacks IN(SELECT IdFeedBacks FROM DELETED);
            END;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
