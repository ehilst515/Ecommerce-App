using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.Migrations
{
    public partial class Fix_CartItem_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CartItems_CartUserId_CartProductId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartUserId_CartProductId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartProductId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartUserId",
                table: "AspNetUsers");

            // Make sure table is empty!
            migrationBuilder.Sql("DELETE FROM CartItems");

            migrationBuilder.DropPrimaryKey("PK_CartItems", "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CartItems",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey("PK_CartItems", "CartItems", new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_UserId",
                table: "CartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_UserId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey("PK_CartItems", "CartItems");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey("PK_CartItems", "CartItems", new[] { "UserId", "ProductId" });

            migrationBuilder.AddColumn<long>(
                name: "CartProductId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CartUserId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartUserId_CartProductId",
                table: "AspNetUsers",
                columns: new[] { "CartUserId", "CartProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CartItems_CartUserId_CartProductId",
                table: "AspNetUsers",
                columns: new[] { "CartUserId", "CartProductId" },
                principalTable: "CartItems",
                principalColumns: new[] { "UserId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}