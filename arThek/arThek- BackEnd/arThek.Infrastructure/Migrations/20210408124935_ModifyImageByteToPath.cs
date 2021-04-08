using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace arThek.Infrastructure.Migrations
{
    public partial class ModifyImageByteToPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Mentees");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Mentors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Mentees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                column: "ProfileImagePath",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Mentees");

            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Admins");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "Mentors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "Mentees",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "Admins",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                column: "ProfileImage",
                value: new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }
    }
}
