using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamSearch.Migrations
{
    public partial class AddedPasswordOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "USERS",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "USERS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "USERS");
        }
    }
}
