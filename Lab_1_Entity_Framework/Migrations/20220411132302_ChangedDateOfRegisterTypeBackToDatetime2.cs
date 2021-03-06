using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_1_Entity_Framework.Migrations
{
    public partial class ChangedDateOfRegisterTypeBackToDatetime2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfRegister",
                table: "Leaves",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfRegister",
                table: "Leaves",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
