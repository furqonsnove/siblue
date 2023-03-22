﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using siblue.Db;

#nullable disable

namespace siblue.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("siblue.Model.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsPaidLeave")
                        .HasColumnType("boolean")
                        .HasColumnName("is_paid_leave");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("joined_at");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Nik")
                        .HasColumnType("text")
                        .HasColumnName("nik");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid")
                        .HasColumnName("position_id");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.HasIndex("PositionId")
                        .HasDatabaseName("ix_employees_position_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_employees_user_id");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("siblue.Model.ListBackup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("EmployeeBackupId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_backup_id");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_id");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_list_backups");

                    b.HasIndex("EmployeeBackupId")
                        .HasDatabaseName("ix_list_backups_employee_backup_id");

                    b.HasIndex("EmployeeId")
                        .HasDatabaseName("ix_list_backups_employee_id");

                    b.ToTable("list_backups", (string)null);
                });

            modelBuilder.Entity("siblue.Model.LogAudit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Activity")
                        .HasColumnType("text")
                        .HasColumnName("activity");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Detail")
                        .HasColumnType("text")
                        .HasColumnName("detail");

                    b.Property<string>("Modul")
                        .HasColumnType("text")
                        .HasColumnName("modul");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_log_audits");

                    b.ToTable("log_audits", (string)null);
                });

            modelBuilder.Entity("siblue.Model.LogNotif", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_id");

                    b.Property<string>("NotificationBody")
                        .HasColumnType("text")
                        .HasColumnName("notification_body");

                    b.Property<string>("NotificationTitle")
                        .HasColumnType("text")
                        .HasColumnName("notification_title");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_log_notifs");

                    b.HasIndex("EmployeeId")
                        .HasDatabaseName("ix_log_notifs_employee_id");

                    b.ToTable("log_notifs", (string)null);
                });

            modelBuilder.Entity("siblue.Model.PaidLeaveApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ApplicationStatus")
                        .HasColumnType("text")
                        .HasColumnName("application_status");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid?>("EmployeeBackupId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_backup_id");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_id");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expired_at");

                    b.Property<DateTime>("PaidLeaveEndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("paid_leave_end_date");

                    b.Property<DateTime>("PaidLeaveStartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("paid_leave_start_date");

                    b.Property<Guid?>("ReviewerId")
                        .HasColumnType("uuid")
                        .HasColumnName("reviewer_id");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_paid_leave_applications");

                    b.HasIndex("EmployeeBackupId")
                        .HasDatabaseName("ix_paid_leave_applications_employee_backup_id");

                    b.HasIndex("EmployeeId")
                        .HasDatabaseName("ix_paid_leave_applications_employee_id");

                    b.HasIndex("ReviewerId")
                        .HasDatabaseName("ix_paid_leave_applications_reviewer_id");

                    b.ToTable("paid_leave_applications", (string)null);
                });

            modelBuilder.Entity("siblue.Model.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int?>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_positions");

                    b.ToTable("positions", (string)null);
                });

            modelBuilder.Entity("siblue.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<DateTime>("PasswordExpiredAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("password_expired_at");

                    b.Property<string>("Pin")
                        .HasColumnType("text")
                        .HasColumnName("pin");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("siblue.Model.Employee", b =>
                {
                    b.HasOne("siblue.Model.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_employees_positions_position_id");

                    b.HasOne("siblue.Model.User", "User")
                        .WithMany("Employees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_employees_users_user_id");

                    b.Navigation("Position");

                    b.Navigation("User");
                });

            modelBuilder.Entity("siblue.Model.ListBackup", b =>
                {
                    b.HasOne("siblue.Model.Employee", "EmployeeBackup")
                        .WithMany()
                        .HasForeignKey("EmployeeBackupId")
                        .HasConstraintName("fk_list_backups_employees_employee_backup_id");

                    b.HasOne("siblue.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("fk_list_backups_employees_employee_id");

                    b.Navigation("Employee");

                    b.Navigation("EmployeeBackup");
                });

            modelBuilder.Entity("siblue.Model.LogNotif", b =>
                {
                    b.HasOne("siblue.Model.Employee", "Employee")
                        .WithMany("Notifications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_log_notifs_employees_employee_id");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("siblue.Model.PaidLeaveApplication", b =>
                {
                    b.HasOne("siblue.Model.Employee", "EmployeeBackup")
                        .WithMany()
                        .HasForeignKey("EmployeeBackupId")
                        .HasConstraintName("fk_paid_leave_applications_employees_employee_backup_id");

                    b.HasOne("siblue.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("fk_paid_leave_applications_employees_employee_id");

                    b.HasOne("siblue.Model.Employee", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .HasConstraintName("fk_paid_leave_applications_employees_reviewer_id");

                    b.Navigation("Employee");

                    b.Navigation("EmployeeBackup");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("siblue.Model.Employee", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("siblue.Model.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("siblue.Model.User", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
