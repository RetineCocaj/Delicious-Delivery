using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_CartItems_CartItemId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_CartItemId",
                table: "FoodItems");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CartItemId",
                table: "FoodItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CartItemId",
                table: "FoodItems",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CartItemId",
                table: "FoodItems",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_CartItems_CartItemId",
                table: "FoodItems",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "CartItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}