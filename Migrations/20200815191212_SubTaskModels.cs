using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.Migrations
{
    public partial class SubTaskModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubtaskId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subtasks",
                columns: table => new
                {
                    SubtaskId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtasks", x => x.SubtaskId);
                    table.ForeignKey(
                        name: "FK_Subtasks_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subtasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subtasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SubtaskId",
                table: "Comments",
                column: "SubtaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_DeveloperId",
                table: "Subtasks",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_TaskId",
                table: "Subtasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_UserId",
                table: "Subtasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Subtasks_SubtaskId",
                table: "Comments",
                column: "SubtaskId",
                principalTable: "Subtasks",
                principalColumn: "SubtaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subtasks_SubtaskId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Subtasks");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SubtaskId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SubtaskId",
                table: "Comments");
        }
    }
}
