using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRINV.Infrastructure.Migrations
{
    public partial class AddingIntegrationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegrationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationModelEndpoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationModelId = table.Column<int>(type: "int", nullable: false),
                    QueryUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpRequestType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationModelEndpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationModelEndpoints_IntegrationModels_IntegrationModelId",
                        column: x => x.IntegrationModelId,
                        principalTable: "IntegrationModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationModelEndpoints_IntegrationModelId",
                table: "IntegrationModelEndpoints",
                column: "IntegrationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationModelEndpoints");

            migrationBuilder.DropTable(
                name: "IntegrationModels");
        }
    }
}
