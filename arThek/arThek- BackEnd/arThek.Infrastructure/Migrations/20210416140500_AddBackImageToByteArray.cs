using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace arThek.Infrastructure.Migrations
{
    public partial class AddBackImageToByteArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImagePath",
                table: "Mentors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImagePath",
                table: "Mentees",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImagePath",
                table: "Admins",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                column: "ProfileImagePath",
                value: new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
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
        }
    }
}
