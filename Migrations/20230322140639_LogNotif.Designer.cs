﻿// <auto-generated />
using System;
using HR_Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HR_Service.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20230322140639_LogNotif")]
    partial class LogNotif
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HR_Service.Models.Masters.LogNotification", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("employee_id")
                        .HasColumnType("uuid");

                    b.Property<string>("notification_body")
                        .HasColumnType("text");

                    b.Property<string>("notification_title")
                        .HasColumnType("text");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("log_notif");
                });

#pragma warning restore 612, 618
        }
    }
}
