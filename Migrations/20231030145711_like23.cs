using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenORM.Migrations
{
    public partial class like23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habit_Category_CategoryId",
                table: "Habit");

            migrationBuilder.DropForeignKey(
                name: "FK_Habit_Users_CreatorId",
                table: "Habit");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Habit_HabitId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Users_UserId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habit",
                table: "Habit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "Habit",
                newName: "Habits");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UserId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_HabitId",
                table: "Likes",
                newName: "IX_Likes_HabitId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Habits",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_Habit_CreatorId",
                table: "Habits",
                newName: "IX_Habits_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Habit_CategoryId",
                table: "Habits",
                newName: "IX_Habits_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habits",
                table: "Habits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Categories_CategoryId",
                table: "Habits",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Users_CreatorId",
                table: "Habits",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Habits_HabitId",
                table: "Likes",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Categories_CategoryId",
                table: "Habits");

            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Users_CreatorId",
                table: "Habits");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Habits_HabitId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habits",
                table: "Habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameTable(
                name: "Habits",
                newName: "Habit");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "Like",
                newName: "IX_Like_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_HabitId",
                table: "Like",
                newName: "IX_Like_HabitId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Habit",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Habits_CreatorId",
                table: "Habit",
                newName: "IX_Habit_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Habits_CategoryId",
                table: "Habit",
                newName: "IX_Habit_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habit",
                table: "Habit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_Category_CategoryId",
                table: "Habit",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_Users_CreatorId",
                table: "Habit",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Habit_HabitId",
                table: "Like",
                column: "HabitId",
                principalTable: "Habit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Users_UserId",
                table: "Like",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
