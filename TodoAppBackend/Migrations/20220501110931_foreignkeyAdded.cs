using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAppBackend.Migrations
{
    public partial class foreignkeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
