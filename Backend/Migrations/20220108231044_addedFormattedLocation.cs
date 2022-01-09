using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticsAPI.Migrations
{
    public partial class addedFormattedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormattedLocation",
                table: "Transactions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormattedLocation",
                table: "Transactions");
        }
    }
}
