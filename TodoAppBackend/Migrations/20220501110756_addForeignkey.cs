using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAppBackend.Migrations
{
    public partial class addForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ApplicationUserId",
                table: "Tasks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_ApplicationUserId",
                table: "Tasks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_ApplicationUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ApplicationUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Tasks");
        }
    }
}
