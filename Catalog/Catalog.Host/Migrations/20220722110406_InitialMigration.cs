using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Host.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_mechanic_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogMechanic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Mechanic = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogMechanic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: false),
                    CatalogMechanicId = table.Column<int>(type: "integer", nullable: false),
                    CatalogCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogCategory_CatalogCategoryId",
                        column: x => x.CatalogCategoryId,
                        principalTable: "CatalogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogMechanic_CatalogMechanicId",
                        column: x => x.CatalogMechanicId,
                        principalTable: "CatalogMechanic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogCategoryId",
                table: "Catalog",
                column: "CatalogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogMechanicId",
                table: "Catalog",
                column: "CatalogMechanicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogCategory");

            migrationBuilder.DropTable(
                name: "CatalogMechanic");

            migrationBuilder.DropSequence(
                name: "catalog_category_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_mechanic_hilo");
        }
    }
}
