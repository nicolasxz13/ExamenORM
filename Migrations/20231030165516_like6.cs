using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenORM.Migrations
{
    public partial class like6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                newName: "IX_Likes_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_CreatorId",
                table: "Likes",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_CreatorId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_CreatorId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
