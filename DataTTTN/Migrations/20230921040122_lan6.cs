using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataTTTN.Migrations
{
    public partial class lan6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_Products_details_Product_DetailsId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_brands_Id_Brand",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_categories_Id_Category",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_materials_Id_Material",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_soles_Id_Sole",
                table: "Products_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_soles",
                table: "soles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materials",
                table: "materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.RenameTable(
                name: "soles",
                newName: "Soles");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_images_Product_DetailsId",
                table: "Images",
                newName: "IX_Images_Product_DetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Soles",
                table: "Soles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_account = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Accounts_Id_account",
                        column: x => x.Id_account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Noti_conten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_account = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts_Id_account",
                        column: x => x.Id_account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Details",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_productdetails = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Cart = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_DetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cart_Details_Carts_Id_Cart",
                        column: x => x.Id_Cart,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Details_Products_details_Product_DetailsId",
                        column: x => x.Product_DetailsId,
                        principalTable: "Products_details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id_User",
                table: "Accounts",
                column: "Id_User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Details_Id_Cart",
                table: "Cart_Details",
                column: "Id_Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Details_Product_DetailsId",
                table: "Cart_Details",
                column: "Product_DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id_account",
                table: "Carts",
                column: "Id_account");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Id_account",
                table: "Notifications",
                column: "Id_account");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_details_Product_DetailsId",
                table: "Images",
                column: "Product_DetailsId",
                principalTable: "Products_details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Brands_Id_Brand",
                table: "Products_details",
                column: "Id_Brand",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Categories_Id_Category",
                table: "Products_details",
                column: "Id_Category",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Materials_Id_Material",
                table: "Products_details",
                column: "Id_Material",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_details_Soles_Id_Sole",
                table: "Products_details",
                column: "Id_Sole",
                principalTable: "Soles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_details_Product_DetailsId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Brands_Id_Brand",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Categories_Id_Category",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Materials_Id_Material",
                table: "Products_details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_details_Soles_Id_Sole",
                table: "Products_details");

            migrationBuilder.DropTable(
                name: "Cart_Details");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Soles",
                table: "Soles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Soles",
                newName: "soles");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "materials");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "brands");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Product_DetailsId",
                table: "images",
                newName: "IX_images_Product_DetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_soles",
                table: "soles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materials",
                table: "materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_Products_details_Product_DetailsId",
                table: "images",
                column: "Product_DetailsId",
                principalTable: "Products_details",
                principalColumn: "Id");

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
                name: "FK_Products_details_materials_Id_Material",
                table: "Products_details",
                column: "Id_Material",
                principalTable: "materials",
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
    }
}
