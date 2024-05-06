using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webproject.Migrations
{
    /// <inheritdoc />
    public partial class Audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IslamabadUnited");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "QuettaGladiators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "QuettaGladiators",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "QuettaGladiators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "QuettaGladiators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PeshawarZalmi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "PeshawarZalmi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PeshawarZalmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "PeshawarZalmi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MultanSultans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "MultanSultans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "MultanSultans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "MultanSultans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LahoreQalandars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "LahoreQalandars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "LahoreQalandars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "LahoreQalandars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "KarachiKings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "KarachiKings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "KarachiKings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "KarachiKings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuettaGladiators");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "QuettaGladiators");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QuettaGladiators");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "QuettaGladiators");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PeshawarZalmi");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "PeshawarZalmi");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PeshawarZalmi");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "PeshawarZalmi");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MultanSultans");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "MultanSultans");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "MultanSultans");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "MultanSultans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LahoreQalandars");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "LahoreQalandars");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "LahoreQalandars");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "LahoreQalandars");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KarachiKings");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "KarachiKings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "KarachiKings");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "KarachiKings");

            migrationBuilder.CreateTable(
                name: "IslamabadUnited",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslamabadUnited", x => x.Id);
                });
        }
    }
}
