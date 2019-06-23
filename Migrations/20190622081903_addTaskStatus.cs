using Microsoft.EntityFrameworkCore.Migrations;

namespace taskList.Migrations
{
    public partial class addTaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "taskList");

            migrationBuilder.RenameColumn(
                name: "taskName",
                table: "taskList",
                newName: "TaskName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "taskList",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "dateTimeCreated",
                table: "taskList",
                newName: "DateTimeCreated");

            migrationBuilder.RenameColumn(
                name: "taskId",
                table: "taskList",
                newName: "TaskId");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "taskList",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "taskList");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "taskList",
                newName: "taskName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "taskList",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "DateTimeCreated",
                table: "taskList",
                newName: "dateTimeCreated");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "taskList",
                newName: "taskId");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "taskList",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }
    }
}
