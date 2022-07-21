using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcreteNg.Data.Migrations
{
    public partial class PricingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskItems_ProjectTasks_ProjectTaskId",
                table: "ProjectTaskItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectTaskId",
                table: "ProjectTaskItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "Expenditure",
                table: "ProjectTaskItems",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "ProjectTaskItems",
                type: "real",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "PricingListItems",
                columns: table => new
                {
                    PricingListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricingListId = table.Column<int>(type: "int", nullable: false),
                    PricingListItemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingListItems", x => x.PricingListItemId);
                    table.ForeignKey(
                        name: "FK_PricingListItems_PricingLists_PricingListId",
                        column: x => x.PricingListId,
                        principalTable: "PricingLists",
                        principalColumn: "PricingListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricingListItemId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CostVersion = table.Column<int>(type: "int", nullable: false),
                    IsActiveVersion = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_PricingListItems_PricingListId",
                table: "PricingListItems",
                column: "PricingListId");

            migrationBuilder.CreateIndex(
                name: "IX_PricingLists_EmployerId",
                table: "PricingLists",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskItems_ProjectTasks_ProjectTaskId",
                table: "ProjectTaskItems",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskItems_ProjectTasks_ProjectTaskId",
                table: "ProjectTaskItems");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "PricingListItems");

            migrationBuilder.DropTable(
                name: "PricingLists");

            migrationBuilder.DropColumn(
                name: "Expenditure",
                table: "ProjectTaskItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProjectTaskItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectTaskId",
                table: "ProjectTaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskItems_ProjectTasks_ProjectTaskId",
                table: "ProjectTaskItems",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "ProjectTaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
