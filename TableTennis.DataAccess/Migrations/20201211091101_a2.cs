using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennis.DataAccess.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TeamMember",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeamMember",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "TeamMember",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TeamMember",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TeamMember",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TeamMatch",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeamMatch",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "TeamMatch",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TeamMatch",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TeamMatch",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Team",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Team",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Team",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Schedule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Schedule",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Schedule",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Schedule",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Schedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TeamMatch");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeamMatch");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "TeamMatch");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TeamMatch");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TeamMatch");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Schedule");
        }
    }
}
