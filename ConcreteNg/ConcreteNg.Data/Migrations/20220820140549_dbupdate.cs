using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employers_EmployerId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PricingListItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Partners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employers_EmployerId",
                table: "Users",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employers_EmployerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PricingListItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Partners");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employers_EmployerId",
                table: "Users",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
