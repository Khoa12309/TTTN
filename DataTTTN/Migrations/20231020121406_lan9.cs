using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataTTTN.Migrations
{
    public partial class lan9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_Id_Account",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Id_Account",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id_Account",
                table: "Orders",
                newName: "Id_User");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AccountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "Orders",
                newName: "Id_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Account",
                table: "Orders",
                column: "Id_Account");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_Id_Account",
                table: "Orders",
                column: "Id_Account",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
