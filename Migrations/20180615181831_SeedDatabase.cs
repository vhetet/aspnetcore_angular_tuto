using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3')");

            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeId) VALUES ('Make1-Model1', (SELECT ID FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeId) VALUES ('Make1-Model2', (SELECT ID FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeId) VALUES ('Make2-Model1', (SELECT ID FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeId) VALUES ('Make2-Model2', (SELECT ID FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeId) VALUES ('Make3-Model1', (SELECT ID FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO CarModels (Name, MakeId) VALUES ('Make3-Model2', (SELECT ID FROM Makes WHERE Name = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make1','Make2','Make3')");
        }
    }
}
