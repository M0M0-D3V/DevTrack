using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.Migrations
{
    public partial class Developers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Workspaces_WorkspaceWorkId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_Project_WorkspaceWorkId",
                table: "Projects",
                newName: "IX_Projects_WorkspaceWorkId");

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "Workspaces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationOrgId",
                table: "Workspaces",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationOrgId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                    table.ForeignKey(
                        name: "FK_Developers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Developers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_OrganizationOrgId",
                table: "Workspaces",
                column: "OrganizationOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OrganizationOrgId",
                table: "Projects",
                column: "OrganizationOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProjectId",
                table: "Category",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_ProjectId",
                table: "Developers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_UserId",
                table: "Developers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Organizations_OrganizationOrgId",
                table: "Projects",
                column: "OrganizationOrgId",
                principalTable: "Organizations",
                principalColumn: "OrgId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Workspaces_WorkspaceWorkId",
                table: "Projects",
                column: "WorkspaceWorkId",
                principalTable: "Workspaces",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workspaces_Organizations_OrganizationOrgId",
                table: "Workspaces",
                column: "OrganizationOrgId",
                principalTable: "Organizations",
                principalColumn: "OrgId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Organizations_OrganizationOrgId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Workspaces_WorkspaceWorkId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Workspaces_Organizations_OrganizationOrgId",
                table: "Workspaces");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Workspaces_OrganizationOrgId",
                table: "Workspaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OrganizationOrgId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "Workspaces");

            migrationBuilder.DropColumn(
                name: "OrganizationOrgId",
                table: "Workspaces");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OrganizationOrgId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_WorkspaceWorkId",
                table: "Project",
                newName: "IX_Project_WorkspaceWorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Workspaces_WorkspaceWorkId",
                table: "Project",
                column: "WorkspaceWorkId",
                principalTable: "Workspaces",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
