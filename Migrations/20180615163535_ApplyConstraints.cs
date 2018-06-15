using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class ApplyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_Makes_MakeId",
                table: "CarModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Makes");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "CarModels");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_MakeId",
                table: "CarModels",
                newName: "IX_CarModels_MakeId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarModels",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels");

            migrationBuilder.RenameTable(
                name: "CarModels",
                newName: "CarModel");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModel",
                newName: "IX_CarModel_MakeId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Makes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarModel",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_Makes_MakeId",
                table: "CarModel",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
