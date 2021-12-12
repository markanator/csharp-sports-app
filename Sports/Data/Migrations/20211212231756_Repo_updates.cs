using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsMVC.Data.Migrations
{
    public partial class Repo_updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepoName",
                table: "US_Sports",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepoName",
                table: "US_Sports");
        }
    }
}
