using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class PricingListUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectTaskItemName",
                table: "ProjectTaskItems");

            migrationBuilder.AddColumn<int>(
                name: "PricingListItemId",
                table: "ProjectTaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskItems_PricingListItemId",
                table: "ProjectTaskItems",
                column: "PricingListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskItems_PricingListItems_PricingListItemId",
                table: "ProjectTaskItems",
                column: "PricingListItemId",
                principalTable: "PricingListItems",
                principalColumn: "PricingListItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskItems_PricingListItems_PricingListItemId",
                table: "ProjectTaskItems");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTaskItems_PricingListItemId",
                table: "ProjectTaskItems");

            migrationBuilder.DropColumn(
                name: "PricingListItemId",
                table: "ProjectTaskItems");

            migrationBuilder.AddColumn<string>(
                name: "ProjectTaskItemName",
                table: "ProjectTaskItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
