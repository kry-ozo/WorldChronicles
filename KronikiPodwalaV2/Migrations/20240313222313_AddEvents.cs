using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace KronikiPodwalaV2.Migrations
{
    public partial class AddEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "eventModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(type: "longtext", nullable: false),
                    EventDescription = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventModel", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "eventModel",
                columns: new[] { "Id", "EventDescription", "EventName" },
                values: new object[] { 1, "ABC", "Walentynki" });

            migrationBuilder.InsertData(
                table: "eventModel",
                columns: new[] { "Id", "EventDescription", "EventName" },
                values: new object[] { 2, "ABC", "Walentynki" });

            migrationBuilder.InsertData(
                table: "eventModel",
                columns: new[] { "Id", "EventDescription", "EventName" },
                values: new object[] { 3, "ABC", "Walentynki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventModel");
        }
    }
}
