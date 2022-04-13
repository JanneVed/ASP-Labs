using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_1_Entity_Framework.Migrations
{
    public partial class AddedLeaveTypeToLeaveTableChangedEndDateToNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfLeave",
                table: "Leaves",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfLeave",
                table: "Leaves");
        }
    }
}
