using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRSBankSystem.Migrations
{
    public partial class AddSessionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SessionId",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Users");
        }
    }
}
