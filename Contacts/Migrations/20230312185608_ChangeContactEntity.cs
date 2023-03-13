using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.Migrations
{
    public partial class ChangeContactEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_CreatedById",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CreatedById",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CreatedById",
                table: "Contacts",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_CreatedById",
                table: "Contacts",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
