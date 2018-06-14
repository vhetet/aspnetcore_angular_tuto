using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class InitialCreateAddFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeatureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });
            migrationBuilder.Sql($"INSERT INTO Features (FeatureName) VALUES ('airbag');");
            migrationBuilder.Sql($"INSERT INTO Features (FeatureName) VALUES ('4 wheel drive');");
            migrationBuilder.Sql($"INSERT INTO Features (FeatureName) VALUES ('AC');");
            migrationBuilder.Sql($"INSERT INTO Features (FeatureName) VALUES ('Trunk');");
            migrationBuilder.Sql($"INSERT INTO Features (FeatureName) VALUES ('Doors');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
