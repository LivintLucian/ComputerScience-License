using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace arThek.Infrastructure.Migrations
{
    public partial class ModifyMentorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatMessageId",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ChatMessageId",
                table: "Mentees");

            migrationBuilder.DropColumn(
                name: "ChatMessageId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Mentors",
                newName: "LinkdlnUrl");

            migrationBuilder.AddColumn<string>(
                name: "BehanceUrl",
                table: "Mentors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarbonMadeUrl",
                table: "Mentors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DribbleUrl",
                table: "Mentors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                column: "LinkdlnUrl",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BehanceUrl",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "CarbonMadeUrl",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "DribbleUrl",
                table: "Mentors");

            migrationBuilder.RenameColumn(
                name: "LinkdlnUrl",
                table: "Mentors",
                newName: "Experience");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatMessageId",
                table: "Mentors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatMessageId",
                table: "Mentees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatMessageId",
                table: "Admins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                columns: new[] { "ChatMessageId", "Experience" },
                values: new object[] { new Guid("c070b2a0-2b90-40c1-80ea-722294ceccf3"), "I've on the market since 2007" });
        }
    }
}
