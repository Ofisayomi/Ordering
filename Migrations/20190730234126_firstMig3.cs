using Microsoft.EntityFrameworkCore.Migrations;

namespace Order_Manager.Migrations
{
    public partial class firstMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Offices_OfficeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OfficeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfficeId",
                table: "Orders",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Offices_OfficeId",
                table: "Orders",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
