using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KronikiPodwalaV2.Migrations
{
    public partial class repairDeletig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_AspNetUsers_CommentOwner",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_eventModel_CommentedEvent",
                table: "comment");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_AspNetUsers_CommentOwner",
                table: "comment",
                column: "CommentOwner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_eventModel_CommentedEvent",
                table: "comment",
                column: "CommentedEvent",
                principalTable: "eventModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_AspNetUsers_CommentOwner",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_eventModel_CommentedEvent",
                table: "comment");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_AspNetUsers_CommentOwner",
                table: "comment",
                column: "CommentOwner",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_eventModel_CommentedEvent",
                table: "comment",
                column: "CommentedEvent",
                principalTable: "eventModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
