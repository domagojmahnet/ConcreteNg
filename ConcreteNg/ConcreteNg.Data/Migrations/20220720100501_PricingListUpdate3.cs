using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class PricingListUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricingListItems_PricingLists_PricingListId",
                table: "PricingListItems");

            migrationBuilder.DropTable(
                name: "PricingLists");

            migrationBuilder.RenameColumn(
                name: "PricingListId",
                table: "PricingListItems",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_PricingListItems_PricingListId",
                table: "PricingListItems",
                newName: "IX_PricingListItems_EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PricingListItems_Employers_EmployerId",
                table: "PricingListItems",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricingListItems_Employers_EmployerId",
                table: "PricingListItems");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "PricingListItems",
                newName: "PricingListId");

            migrationBuilder.RenameIndex(
                name: "IX_PricingListItems_EmployerId",
                table: "PricingListItems",
                newName: "IX_PricingListItems_PricingListId");

            migrationBuilder.CreateTable(
                name: "PricingLists",
                columns: table => new
                {
                    PricingListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingLists", x => x.PricingListId);
                    table.ForeignKey(
                        name: "FK_PricingLists_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PricingLists_EmployerId",
                table: "PricingLists",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PricingListItems_PricingLists_PricingListId",
                table: "PricingListItems",
                column: "PricingListId",
                principalTable: "PricingLists",
                principalColumn: "PricingListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
