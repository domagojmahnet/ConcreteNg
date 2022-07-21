using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class PricingListUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "PricingListItems",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasurement",
                table: "PricingListItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "PricingListItems");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasurement",
                table: "PricingListItems");

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricingListItemId = table.Column<int>(type: "int", nullable: false),
                    CostVersion = table.Column<int>(type: "int", nullable: false),
                    IsActiveVersion = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                    table.ForeignKey(
                        name: "FK_Costs_PricingListItems_PricingListItemId",
                        column: x => x.PricingListItemId,
                        principalTable: "PricingListItems",
                        principalColumn: "PricingListItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_PricingListItemId",
                table: "Costs",
                column: "PricingListItemId");
        }
    }
}
