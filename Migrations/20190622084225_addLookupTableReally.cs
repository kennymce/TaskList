using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace taskList.Migrations
{
    public partial class addLookupTableReally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "taskList",
                newName: "TaskStatusId");

            migrationBuilder.CreateTable(
                name: "taskStatus",
                columns: table => new
                {
                    TaskStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskStatus", x => x.TaskStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taskStatus");

            migrationBuilder.RenameColumn(
                name: "TaskStatusId",
                table: "taskList",
                newName: "StatusId");
        }
    }
}
