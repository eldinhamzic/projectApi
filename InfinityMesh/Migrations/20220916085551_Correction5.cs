using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityMesh.Migrations
{
    public partial class Correction5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfVotes",
                table: "Votes",
                newName: "AllVotes");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                table: "Constituencies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                table: "Constituencies");

            migrationBuilder.RenameColumn(
                name: "AllVotes",
                table: "Votes",
                newName: "NumberOfVotes");
        }
    }
}
