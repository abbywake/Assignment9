using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment9.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movies1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies1",
                table: "Movies1",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies1",
                table: "Movies1");

            migrationBuilder.RenameTable(
                name: "Movies1",
                newName: "Movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieID");
        }
    }
}
