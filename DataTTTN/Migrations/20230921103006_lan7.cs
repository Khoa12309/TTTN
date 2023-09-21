using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataTTTN.Migrations
{
    public partial class lan7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detailed_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Account = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<float>(type: "real", nullable: false),
                    Transportfee = table.Column<float>(type: "real", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_Id_Account",
                        column: x => x.Id_Account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Id_order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_productDetails = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_DetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_Id_order",
                        column: x => x.Id_order,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_details_Product_DetailsId",
                        column: x => x.Product_DetailsId,
                        principalTable: "Products_details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistories_Orders_Id_order",
                        column: x => x.Id_order,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Orders_Id_order",
                        column: x => x.Id_order,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account_Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Account = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Voucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Vouchers_Accounts_Id_Account",
                        column: x => x.Id_Account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Vouchers_Vouchers_Id_Voucher",
                        column: x => x.Id_Voucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Voucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeforPrice = table.Column<float>(type: "real", nullable: false),
                    AfterPrice = table.Column<float>(type: "real", nullable: false),
                    DiscountPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Orders_Id_order",
                        column: x => x.Id_order,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Vouchers_Id_Voucher",
                        column: x => x.Id_Voucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Vouchers_Id_Account",
                table: "Account_Vouchers",
                column: "Id_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Vouchers_Id_Voucher",
                table: "Account_Vouchers",
                column: "Id_Voucher");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Id_User",
                table: "Addresses",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Id_order",
                table: "OrderDetails",
                column: "Id_order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Product_DetailsId",
                table: "OrderDetails",
                column: "Product_DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_Id_order",
                table: "OrderHistories",
                column: "Id_order");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Account",
                table: "Orders",
                column: "Id_Account");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Id_order",
                table: "PaymentMethods",
                column: "Id_order");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_Id_order",
                table: "VoucherDetails",
                column: "Id_order");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_Id_Voucher",
                table: "VoucherDetails",
                column: "Id_Voucher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account_Vouchers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHistories");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "VoucherDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
