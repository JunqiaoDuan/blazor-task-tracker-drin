using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TaskItem");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TaskItem",
                newName: "TaskItemStatus");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "TaskItem",
                newName: "TaskItemPriority");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TaskItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "TaskItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "TaskItem",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "TaskItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModBy",
                table: "TaskItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModByName",
                table: "TaskItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModDate",
                table: "TaskItem",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonOfInvalid",
                table: "TaskItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "ModBy",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "ModByName",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "ModDate",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "ReasonOfInvalid",
                table: "TaskItem");

            migrationBuilder.RenameColumn(
                name: "TaskItemStatus",
                table: "TaskItem",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TaskItemPriority",
                table: "TaskItem",
                newName: "Priority");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
