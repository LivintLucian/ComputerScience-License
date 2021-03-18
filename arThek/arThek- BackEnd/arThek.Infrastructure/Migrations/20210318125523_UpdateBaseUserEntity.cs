using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace arThek.Infrastructure.Migrations
{
    public partial class UpdateBaseUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "BaseUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "BaseUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "MenteeId",
                table: "BaseUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MentorId",
                table: "BaseUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseUsers_MenteeId",
                table: "BaseUsers",
                column: "MenteeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUsers_MentorId",
                table: "BaseUsers",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUsers_Mentees_MenteeId",
                table: "BaseUsers",
                column: "MenteeId",
                principalTable: "Mentees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUsers_Mentors_MentorId",
                table: "BaseUsers",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseUsers_Mentees_MenteeId",
                table: "BaseUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUsers_Mentors_MentorId",
                table: "BaseUsers");

            migrationBuilder.DropIndex(
                name: "IX_BaseUsers_MenteeId",
                table: "BaseUsers");

            migrationBuilder.DropIndex(
                name: "IX_BaseUsers_MentorId",
                table: "BaseUsers");

            migrationBuilder.DropColumn(
                name: "MenteeId",
                table: "BaseUsers");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "BaseUsers");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "BaseUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "BaseUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
