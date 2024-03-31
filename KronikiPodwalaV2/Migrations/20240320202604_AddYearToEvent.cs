using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KronikiPodwalaV2.Migrations
{
    public partial class AddYearToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventYear",
                table: "eventModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "eventModel",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventYear",
                value: 2022);

            migrationBuilder.UpdateData(
                table: "eventModel",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventYear",
                value: 2021);

            migrationBuilder.UpdateData(
                table: "eventModel",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventYear",
                value: 2020);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventYear",
                table: "eventModel");
        }
    }
}
