using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataTTTN.Migrations
{
    public partial class lan5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sole",
                table: "Sole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Sole",
                newName: "soles");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "materials");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_soles",
                table: "soles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materials",
                table: "materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Product_details = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_DetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_Products_details_Product_DetailsId",
                        column: x => x.Product_DetailsId,
                        principalTable: "Products_details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_images_Product_DetailsId",
                table: "images",
                column: "Product_DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_brands_Id_Brand",
                table: "Products_details",
                column: "Id_Brand",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_categories_Id_Category",
                table: "Products_details",
                column: "Id_Category",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Colors_Id_Color",
                table: "Products_details",
                column: "Id_Color",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_materials_Id_Material",
                table: "Products_details",
                column: "Id_Material",
                principalTable: "materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Products_Id_Product",
                table: "Products_details",
                column: "Id_Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_soles_Id_Sole",
                table: "Products_details",
                column: "Id_Sole",
                principalTable: "soles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_brands_Id_Brand",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_categories_Id_Category",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Colors_Id_Color",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_materials_Id_Material",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Products_Id_Product",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_soles_Id_Sole",
                table: "Products_details");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_soles",
                table: "soles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materials",
                table: "materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.RenameTable(
                name: "soles",
                newName: "Sole");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sole",
                table: "Sole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

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
    }
}
