using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Northwind.Migrations
{
    public partial class UpdateProductsAndTerritories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerDemo_Customers_CustomerId",
                table: "CustomerCustomerDemo");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerDemo_CustomerDemographics_CustomerTypeId",
                table: "CustomerCustomerDemo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCustomerDemo",
                table: "CustomerCustomerDemo");

            migrationBuilder.RenameTable(
                name: "CustomerCustomerDemo",
                newName: "CustomerCustomerDemos");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeId",
                table: "CustomerCustomerDemos",
                newName: "IX_CustomerCustomerDemos_CustomerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCustomerDemos",
                table: "CustomerCustomerDemos",
                columns: new[] { "CustomerId", "CustomerTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerDemos_Customers_CustomerId",
                table: "CustomerCustomerDemos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerDemos_CustomerDemographics_CustomerTypeId",
                table: "CustomerCustomerDemos",
                column: "CustomerTypeId",
                principalTable: "CustomerDemographics",
                principalColumn: "CustomerTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerDemos_Customers_CustomerId",
                table: "CustomerCustomerDemos");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerDemos_CustomerDemographics_CustomerTypeId",
                table: "CustomerCustomerDemos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCustomerDemos",
                table: "CustomerCustomerDemos");

            migrationBuilder.RenameTable(
                name: "CustomerCustomerDemos",
                newName: "CustomerCustomerDemo");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCustomerDemos_CustomerTypeId",
                table: "CustomerCustomerDemo",
                newName: "IX_CustomerCustomerDemo_CustomerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCustomerDemo",
                table: "CustomerCustomerDemo",
                columns: new[] { "CustomerId", "CustomerTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerDemo_Customers_CustomerId",
                table: "CustomerCustomerDemo",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerDemo_CustomerDemographics_CustomerTypeId",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeId",
                principalTable: "CustomerDemographics",
                principalColumn: "CustomerTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
