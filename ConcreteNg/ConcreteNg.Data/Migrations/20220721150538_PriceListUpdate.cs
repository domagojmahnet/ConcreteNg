using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class PriceListUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricingListItems_Employers_EmployerId",
                table: "PricingListItems");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "PricingListItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PricingListItems_Employers_EmployerId",
                table: "PricingListItems",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricingListItems_Employers_EmployerId",
                table: "PricingListItems");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "PricingListItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PricingListItems_Employers_EmployerId",
                table: "PricingListItems",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
