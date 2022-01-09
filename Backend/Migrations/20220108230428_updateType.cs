using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticsAPI.Migrations
{
    public partial class updateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeString",
                table: "Transactions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeString",
                table: "Transactions");
        }
    }
}
