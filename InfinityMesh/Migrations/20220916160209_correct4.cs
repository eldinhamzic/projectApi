using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityMesh.Migrations
{
    public partial class correct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllVotes",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllVotes",
                table: "Votes");
        }
    }
}
