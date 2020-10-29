using Microsoft.EntityFrameworkCore.Migrations;

namespace SULS.Migrations
{
    public partial class AddingSubbmissionsCollectionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Problems");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Problems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Problems");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
