using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace arThek.Infrastructure.Migrations
{
    public partial class ModifyProperties_ChatMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenteeId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ChatMessages",
                newName: "UserType");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageDate",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MsgText",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "MessageDate",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "MsgText",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "User",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "ChatMessages",
                newName: "Content");

            migrationBuilder.AddColumn<Guid>(
                name: "MenteeId",
                table: "ChatMessages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MentorId",
                table: "ChatMessages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
