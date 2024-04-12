using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace KronikiPodwalaV2.Migrations
{
    public partial class AddComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: false),
                    isReported = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CommentOwner = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_AspNetUsers_CommentOwner",
                        column: x => x.CommentOwner,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "comment",
                columns: new[] { "Id", "CommentOwner", "Text", "isReported" },
                values: new object[] { 1, "7dd706b0-b7e3-4020-ad17-d822cd5beee2", "Interesting", false });

            migrationBuilder.InsertData(
                table: "comment",
                columns: new[] { "Id", "CommentOwner", "Text", "isReported" },
                values: new object[] { 2, "7dd706b0-b7e3-4020-ad17-d822cd5beee2", "Interesting", false });

            migrationBuilder.InsertData(
                table: "comment",
                columns: new[] { "Id", "CommentOwner", "Text", "isReported" },
                values: new object[] { 3, "7dd706b0-b7e3-4020-ad17-d822cd5beee2", "Interesting", false });

            migrationBuilder.CreateIndex(
                name: "IX_comment_CommentOwner",
                table: "comment",
                column: "CommentOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");
        }
    }
}
