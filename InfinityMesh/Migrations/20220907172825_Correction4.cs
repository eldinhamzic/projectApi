using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityMesh.Migrations
{
    public partial class Correction4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateCode",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateName",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstituencyName",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateCode",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "CandidateName",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ConstituencyName",
                table: "Votes");
        }
    }
}
