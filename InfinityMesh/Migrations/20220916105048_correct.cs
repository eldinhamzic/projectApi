using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityMesh.Migrations
{
    public partial class correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverrideFile",
                table: "Votes");

            migrationBuilder.AddColumn<int>(
                name: "VotesFromConstituency",
                table: "Constituencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OverrideFile",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VotesFromConstituency",
                table: "Constituencies");

            migrationBuilder.DropColumn(
                name: "OverrideFile",
                table: "Candidates");

            migrationBuilder.AddColumn<bool>(
                name: "OverrideFile",
                table: "Votes",
                type: "bit",
                nullable: true);
        }
    }
}
