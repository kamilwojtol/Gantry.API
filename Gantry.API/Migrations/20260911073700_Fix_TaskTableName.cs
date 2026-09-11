using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gantry.API.Migrations
{
    /// <inheritdoc />
    public partial class Fix_TaskTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_KanbanBoards_KanbanId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_KanbanId",
                table: "Tasks",
                newName: "IX_Tasks_KanbanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_KanbanBoards_KanbanId",
                table: "Tasks",
                column: "KanbanId",
                principalTable: "KanbanBoards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_KanbanBoards_KanbanId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_KanbanId",
                table: "Task",
                newName: "IX_Task_KanbanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_KanbanBoards_KanbanId",
                table: "Task",
                column: "KanbanId",
                principalTable: "KanbanBoards",
                principalColumn: "Id");
        }
    }
}
