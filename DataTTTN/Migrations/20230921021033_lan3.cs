using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataTTTN.Migrations
{
    public partial class lan3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Size = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_details_Sizes_Id_Size",
                        column: x => x.Id_Size,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Size",
                table: "Products_details",
                column: "Id_Size");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_details");
        }
    }
}
