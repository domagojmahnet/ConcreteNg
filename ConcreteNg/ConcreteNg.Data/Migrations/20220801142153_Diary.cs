using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class Diary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Employers_EmployerId",
                table: "Partners");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "Partners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "TotalCost",
                table: "Expenses",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "DiaryItems",
                columns: table => new
                {
                    DiaryItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryItems", x => x.DiaryItemId);
                    table.ForeignKey(
                        name: "FK_DiaryItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaryItems_ProjectId",
                table: "DiaryItems",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Employers_EmployerId",
                table: "Partners",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Employers_EmployerId",
                table: "Partners");

            migrationBuilder.DropTable(
                name: "DiaryItems");

            migrationBuilder.AlterColumn<int>(
                name: "EmployerId",
                table: "Partners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TotalCost",
                table: "Expenses",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Employers_EmployerId",
                table: "Partners",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
