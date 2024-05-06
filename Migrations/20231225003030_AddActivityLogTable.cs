using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostMidProject.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "ActivityLog",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  ActionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  Timestamp = table.Column<DateTime>(type: "date", nullable: true),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_ActivityLog", x => x.Id);
              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
