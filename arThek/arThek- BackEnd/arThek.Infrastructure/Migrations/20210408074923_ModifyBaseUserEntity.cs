using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace arThek.Infrastructure.Migrations
{
    public partial class ModifyBaseUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Mentees");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Mentors",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Mentors",
                newName: "Domain");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Mentors",
                newName: "ConfirmPassword");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Mentees",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Mentees",
                newName: "Domain");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Mentees",
                newName: "ConfirmPassword");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Admins",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Admins",
                newName: "Domain");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Admins",
                newName: "ConfirmPassword");

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                columns: new[] { "ConfirmPassword", "Domain", "UserName" },
                values: new object[] { null, "Designer", "livintlucian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Mentors",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Domain",
                table: "Mentors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Mentors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Mentees",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Domain",
                table: "Mentees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Mentees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admins",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Domain",
                table: "Admins",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Admins",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Mentors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Mentees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "Id",
                keyValue: new Guid("f070b2a0-2b90-40c1-80ea-722294ceccf3"),
                columns: new[] { "Category", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Designer", "Lucian", "Livint", "+40 748 032 932" });
        }
    }
}
