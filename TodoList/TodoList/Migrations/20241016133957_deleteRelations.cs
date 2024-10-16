using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    public partial class deleteRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Users_UserId",
                table: "WorkTasks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_WorkTasks_UserId",
                table: "WorkTasks");

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedEndDate", "UserId" },
                values: new object[] { new DateTime(2024, 10, 16, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3315), new DateTime(2024, 10, 23, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3279), 0 });

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedEndDate", "UserId" },
                values: new object[] { new DateTime(2024, 10, 14, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3319), new DateTime(2024, 10, 20, 15, 39, 56, 915, DateTimeKind.Local).AddTicks(3318), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    NotificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_WorkTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "WorkTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { 1, "jan123@wp.pl", "Jan123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { 2, "jakub123@wp.pl", "Jakub123" });

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedEndDate", "UserId" },
                values: new object[] { new DateTime(2024, 10, 16, 13, 7, 49, 227, DateTimeKind.Local).AddTicks(8844), new DateTime(2024, 10, 23, 13, 7, 49, 227, DateTimeKind.Local).AddTicks(8812), 1 });

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedEndDate", "UserId" },
                values: new object[] { new DateTime(2024, 10, 16, 13, 7, 49, 227, DateTimeKind.Local).AddTicks(8848), new DateTime(2024, 10, 23, 13, 7, 49, 227, DateTimeKind.Local).AddTicks(8846), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_UserId",
                table: "WorkTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TaskId",
                table: "Notifications",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Users_UserId",
                table: "WorkTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
