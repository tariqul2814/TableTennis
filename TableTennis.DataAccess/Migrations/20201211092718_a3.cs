using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennis.DataAccess.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchDate",
                table: "Schedule");

            migrationBuilder.AddColumn<string>(
                name: "MatchDay",
                table: "Schedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchDay",
                table: "Schedule");

            migrationBuilder.AddColumn<DateTime>(
                name: "MatchDate",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
