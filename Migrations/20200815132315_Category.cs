using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Projects_ProjectId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Task",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Category",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_CategoryId",
                table: "Task",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Projects_ProjectId",
                table: "Category",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Category_CategoryId",
                table: "Task",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Projects_ProjectId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Category_CategoryId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_CategoryId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Projects_ProjectId",
                table: "Category",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
