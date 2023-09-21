using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataTTTN.Migrations
{
    public partial class lan4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Products_details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products_details",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Products_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Brand",
                table: "Products_details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Category",
                table: "Products_details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Color",
                table: "Products_details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Material",
                table: "Products_details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Product",
                table: "Products_details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Sole",
                table: "Products_details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_modified_date",
                table: "Products_details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Products_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Brand",
                table: "Products_details",
                column: "Id_Brand");

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Category",
                table: "Products_details",
                column: "Id_Category");

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Color",
                table: "Products_details",
                column: "Id_Color");

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Material",
                table: "Products_details",
                column: "Id_Material");

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Product",
                table: "Products_details",
                column: "Id_Product");

            migrationBuilder.CreateIndex(
                name: "IX_Products_details_Id_Sole",
                table: "Products_details",
                column: "Id_Sole");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Brand_Id_Brand",
                table: "Products_details",
                column: "Id_Brand",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Category_Id_Category",
                table: "Products_details",
                column: "Id_Category",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Color_Id_Color",
                table: "Products_details",
                column: "Id_Color",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Material_Id_Material",
                table: "Products_details",
                column: "Id_Material",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Product_Id_Product",
                table: "Products_details",
                column: "Id_Product",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Sole_Id_Sole",
                table: "Products_details",
                column: "Id_Sole",
                principalTable: "Sole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Brand_Id_Brand",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Category_Id_Category",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Color_Id_Color",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Material_Id_Material",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Product_Id_Product",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Sole_Id_Sole",
                table: "Products_details");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sole");

            migrationBuilder.DropIndex(
                name: "IX_Products_details_Id_Brand",
                table: "Products_details");

            migrationBuilder.DropIndex(
                name: "IX_Products_details_Id_Category",
                table: "Products_details");

            migrationBuilder.DropIndex(
                name: "IX_Products_details_Id_Color",
                table: "Products_details");

            migrationBuilder.DropIndex(
                name: "IX_Products_details_Id_Material",
                table: "Products_details");

            migrationBuilder.DropIndex(
                name: "IX_Products_details_Id_Product",
                table: "Products_details");

            migrationBuilder.DropIndex(
                name: "IX_Products_details_Id_Sole",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Id_Brand",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Id_Category",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Id_Color",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Id_Material",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Id_Product",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Id_Sole",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Last_modified_date",
                table: "Products_details");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products_details");
        }
    }
}
