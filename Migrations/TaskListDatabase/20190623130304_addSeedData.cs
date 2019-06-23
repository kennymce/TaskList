using Microsoft.EntityFrameworkCore.Migrations;

namespace taskList.Migrations.TaskListDatabase
{
    public partial class addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "TaskId", "Description", "TaskName", "TaskStatusId" },
                values: new object[] { 1, "First task description", "First task", 1 });

            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "TaskId", "Description", "TaskName", "TaskStatusId" },
                values: new object[] { 2, "Second task description", "Second task", 2 });

            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "TaskId", "Description", "TaskName", "TaskStatusId" },
                values: new object[] { 3, "Third task description", "Third task", 3 });

            migrationBuilder.InsertData(
                table: "TaskList",
                columns: new[] { "TaskId", "Description", "TaskName", "TaskStatusId" },
                values: new object[] { 4, "First task description", "Fourth task", 4 });

            migrationBuilder.InsertData(
                table: "TaskListStatus",
                columns: new[] { "TaskStatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Not Started" },
                    { 2, "In Progress" },
                    { 3, "Complete" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "TaskId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "TaskId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskList",
                keyColumn: "TaskId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskListStatus",
                keyColumn: "TaskStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskListStatus",
                keyColumn: "TaskStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskListStatus",
                keyColumn: "TaskStatusId",
                keyValue: 3);
        }
    }
}
