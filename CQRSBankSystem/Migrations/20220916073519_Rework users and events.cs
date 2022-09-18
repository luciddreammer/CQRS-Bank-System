using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRSBankSystem.Migrations
{
    public partial class Reworkusersandevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Events",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Events",
                newName: "From");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Events",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Events",
                newName: "FromId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
