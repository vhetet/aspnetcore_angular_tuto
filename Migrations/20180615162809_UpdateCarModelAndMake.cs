using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class UpdateCarModelAndMake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makes_CarModel_CarModelId",
                table: "Makes");

            migrationBuilder.DropIndex(
                name: "IX_Makes_CarModelId",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Makes");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "CarModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_MakeId",
                table: "CarModel",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_Makes_MakeId",
                table: "CarModel",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_Makes_MakeId",
                table: "CarModel");

            migrationBuilder.DropIndex(
                name: "IX_CarModel_MakeId",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "CarModel");

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Makes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_CarModelId",
                table: "Makes",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makes_CarModel_CarModelId",
                table: "Makes",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
