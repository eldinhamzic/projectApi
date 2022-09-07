using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityMesh.Migrations
{
    public partial class Correction3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateCode",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ConstituencyName",
                table: "Votes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateCode",
                table: "Votes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConstituencyName",
                table: "Votes",
                type: "int",
                nullable: true);
        }
    }
}
