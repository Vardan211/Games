using Microsoft.EntityFrameworkCore.Migrations;

namespace Games.DataAcess.Migrations
{
    public partial class AddRecommendForGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE public.\"Games\" SET \"Name\" = CONCAT('Рекомендовано ', \"Name\") WHERE \"Genre\" = 1");
        }
    }
}