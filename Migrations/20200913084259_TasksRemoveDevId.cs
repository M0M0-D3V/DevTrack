using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.Migrations
{
    public partial class TasksRemoveDevId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtasks_Developers_DeveloperId",
                table: "Subtasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DeveloperId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Subtasks_DeveloperId",
                table: "Subtasks");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Subtasks");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToDeveloperId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedToDeveloperId",
                table: "Subtasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedToDeveloperId",
                table: "Tasks",
                column: "AssignedToDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_AssignedToDeveloperId",
                table: "Subtasks",
                column: "AssignedToDeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtasks_Developers_AssignedToDeveloperId",
                table: "Subtasks",
                column: "AssignedToDeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Developers_AssignedToDeveloperId",
                table: "Tasks",
                column: "AssignedToDeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtasks_Developers_AssignedToDeveloperId",
                table: "Subtasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Developers_AssignedToDeveloperId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedToDeveloperId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Subtasks_AssignedToDeveloperId",
                table: "Subtasks");

            migrationBuilder.DropColumn(
                name: "AssignedToDeveloperId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedToDeveloperId",
                table: "Subtasks");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Subtasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DeveloperId",
                table: "Tasks",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_DeveloperId",
                table: "Subtasks",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtasks_Developers_DeveloperId",
                table: "Subtasks",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
