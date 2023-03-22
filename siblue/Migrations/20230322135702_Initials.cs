using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siblue.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "log_audits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    modul = table.Column<string>(type: "text", nullable: true),
                    activity = table.Column<string>(type: "text", nullable: true),
                    detail = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_log_audits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<int>(type: "integer", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    password = table.Column<string>(type: "text", nullable: true),
                    pin = table.Column<string>(type: "text", nullable: true),
                    password_expired_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nik = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: true),
                    joined_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_paid_leave = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                    table.ForeignKey(
                        name: "fk_employees_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employees_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "list_backups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_id = table.Column<Guid>(type: "uuid", nullable: true),
                    employee_backup_id = table.Column<Guid>(type: "uuid", nullable: true),
                    level = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_list_backups", x => x.id);
                    table.ForeignKey(
                        name: "fk_list_backups_employees_employee_backup_id",
                        column: x => x.employee_backup_id,
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_list_backups_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "log_notifs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    notification_title = table.Column<string>(type: "text", nullable: true),
                    notification_body = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_log_notifs", x => x.id);
                    table.ForeignKey(
                        name: "fk_log_notifs_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paid_leave_applications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_id = table.Column<Guid>(type: "uuid", nullable: true),
                    employee_backup_id = table.Column<Guid>(type: "uuid", nullable: true),
                    reviewer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    application_status = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    paid_leave_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    paid_leave_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expired_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paid_leave_applications", x => x.id);
                    table.ForeignKey(
                        name: "fk_paid_leave_applications_employees_employee_backup_id",
                        column: x => x.employee_backup_id,
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_paid_leave_applications_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_paid_leave_applications_employees_reviewer_id",
                        column: x => x.reviewer_id,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_employees_position_id",
                table: "employees",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_user_id",
                table: "employees",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_list_backups_employee_backup_id",
                table: "list_backups",
                column: "employee_backup_id");

            migrationBuilder.CreateIndex(
                name: "ix_list_backups_employee_id",
                table: "list_backups",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_log_notifs_employee_id",
                table: "log_notifs",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_paid_leave_applications_employee_backup_id",
                table: "paid_leave_applications",
                column: "employee_backup_id");

            migrationBuilder.CreateIndex(
                name: "ix_paid_leave_applications_employee_id",
                table: "paid_leave_applications",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_paid_leave_applications_reviewer_id",
                table: "paid_leave_applications",
                column: "reviewer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "list_backups");

            migrationBuilder.DropTable(
                name: "log_audits");

            migrationBuilder.DropTable(
                name: "log_notifs");

            migrationBuilder.DropTable(
                name: "paid_leave_applications");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
