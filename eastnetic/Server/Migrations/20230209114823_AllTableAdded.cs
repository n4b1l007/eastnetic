using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eastnetic.Server.Migrations
{
    /// <inheritdoc />
    public partial class AllTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubElement_Window_WindowId",
                table: "SubElement");

            migrationBuilder.DropForeignKey(
                name: "FK_Window_Orders_OrderId",
                table: "Window");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Window",
                table: "Window");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubElement",
                table: "SubElement");

            migrationBuilder.RenameTable(
                name: "Window",
                newName: "Windows");

            migrationBuilder.RenameTable(
                name: "SubElement",
                newName: "SubElements");

            migrationBuilder.RenameIndex(
                name: "IX_Window_OrderId",
                table: "Windows",
                newName: "IX_Windows_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_SubElement_WindowId",
                table: "SubElements",
                newName: "IX_SubElements_WindowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Windows",
                table: "Windows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubElements",
                table: "SubElements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                table: "SubElements",
                column: "WindowId",
                principalTable: "Windows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                table: "SubElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Windows",
                table: "Windows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubElements",
                table: "SubElements");

            migrationBuilder.RenameTable(
                name: "Windows",
                newName: "Window");

            migrationBuilder.RenameTable(
                name: "SubElements",
                newName: "SubElement");

            migrationBuilder.RenameIndex(
                name: "IX_Windows_OrderId",
                table: "Window",
                newName: "IX_Window_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_SubElements_WindowId",
                table: "SubElement",
                newName: "IX_SubElement_WindowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Window",
                table: "Window",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubElement",
                table: "SubElement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubElement_Window_WindowId",
                table: "SubElement",
                column: "WindowId",
                principalTable: "Window",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Window_Orders_OrderId",
                table: "Window",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
