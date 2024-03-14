using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMCAA.Migrations
{
    public partial class PaymentYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "MembersDetail");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "MembersDetail");

            migrationBuilder.DropColumn(
                name: "ReceiptNo",
                table: "MembersDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptNo",
                table: "Finances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentYear",
                table: "Finances",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentYear",
                table: "Finances");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "MembersDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "MembersDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptNo",
                table: "MembersDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptNo",
                table: "Finances",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
