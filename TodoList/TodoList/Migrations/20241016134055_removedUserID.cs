using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    public partial class removedUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkTasks");

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedEndDate" },
                values: new object[] { new DateTime(2024, 10, 16, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2282), new DateTime(2024, 10, 23, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2255) });

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedEndDate" },
                values: new object[] { new DateTime(2024, 10, 14, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2286), new DateTime(2024, 10, 20, 15, 40, 55, 321, DateTimeKind.Local).AddTicks(2285) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WorkTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedEndDate" },
                values: new object[] { new DateTime(2024, 10, 16, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3315), new DateTime(2024, 10, 23, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedEndDate" },
                values: new object[] { new DateTime(2024, 10, 14, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3319), new DateTime(2024, 10, 20, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3318) });
        }
    }
}
