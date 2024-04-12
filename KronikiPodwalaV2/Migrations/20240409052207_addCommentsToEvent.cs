using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KronikiPodwalaV2.Migrations
{
    public partial class addCommentsToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentedEvent",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "comment",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentedEvent",
                value: 10);

            migrationBuilder.UpdateData(
                table: "comment",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentedEvent",
                value: 10);

            migrationBuilder.UpdateData(
                table: "comment",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentedEvent",
                value: 10);

            migrationBuilder.CreateIndex(
                name: "IX_comment_CommentedEvent",
                table: "comment",
                column: "CommentedEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_eventModel_CommentedEvent",
                table: "comment",
                column: "CommentedEvent",
                principalTable: "eventModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_eventModel_CommentedEvent",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_CommentedEvent",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "CommentedEvent",
                table: "comment");
        }
    }
}
