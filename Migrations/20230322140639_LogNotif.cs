using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Service.Migrations
{
    public partial class LogNotif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_positions",
                table: "positions");

            migrationBuilder.RenameTable(
                name: "positions",
                newName: "Position");

            migrationBuilder.RenameIndex(
                name: "IX_positions_code",
                table: "Position",
                newName: "IX_Position_code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "id");

            migrationBuilder.CreateTable(
                name: "LogNotifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    notification_title = table.Column<string>(type: "text", nullable: true),
                    notification_body = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogNotifications", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "positions");

            migrationBuilder.RenameIndex(
                name: "IX_Position_code",
                table: "positions",
                newName: "IX_positions_code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_positions",
                table: "positions",
                column: "id");
        }
    }
}
