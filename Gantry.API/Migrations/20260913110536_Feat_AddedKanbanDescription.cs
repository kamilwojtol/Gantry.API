using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gantry.API.Migrations
{
    /// <inheritdoc />
    public partial class Feat_AddedKanbanDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "KanbanBoards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "KanbanBoards");
        }
    }
}
