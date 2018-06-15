using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class UpdateMake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Makes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Makes");
        }
    }
}
