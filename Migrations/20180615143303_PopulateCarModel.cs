using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class PopulateCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Scenic');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Safrane');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Clio');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Espace');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Nevada');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Lupo');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Golf');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Passat');");
            migrationBuilder.Sql($"INSERT INTO CarModel (Name) VALUES ('Polo');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
