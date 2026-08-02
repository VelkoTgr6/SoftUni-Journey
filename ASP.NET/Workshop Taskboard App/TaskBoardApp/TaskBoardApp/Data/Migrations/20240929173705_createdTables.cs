using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class createdTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "58fedcf2-8aab-4a78-8639-3403c54ee254", 0, "02b3990e-5ca5-47fa-becc-442b869ce215", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEH2+qOU/zWG5c3hp2C7BWfrZTPRIYxeocL3zkO0pCr2J3geWs9E3LxtX84V+9oGrUw==", null, false, "eb6accbf-9f2d-4061-b2a4-dbb3364250e7", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 13, 20, 37, 5, 303, DateTimeKind.Local).AddTicks(5172), "Implement better styling for all public pages", "58fedcf2-8aab-4a78-8639-3403c54ee254", "Improve CSS styles" },
                    { 2, 2, new DateTime(2024, 9, 24, 20, 37, 5, 303, DateTimeKind.Local).AddTicks(5206), "Implement user registration and login", "58fedcf2-8aab-4a78-8639-3403c54ee254", "Add user authentication" },
                    { 3, 3, new DateTime(2024, 9, 28, 20, 37, 5, 303, DateTimeKind.Local).AddTicks(5210), "Add functionality to create, edit and delete tasks", "58fedcf2-8aab-4a78-8639-3403c54ee254", "Implement task management" },
                    { 4, 3, new DateTime(2024, 9, 28, 20, 37, 5, 303, DateTimeKind.Local).AddTicks(5213), "Implement user roles and permissions", "58fedcf2-8aab-4a78-8639-3403c54ee254", "Add user roles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58fedcf2-8aab-4a78-8639-3403c54ee254");
        }
    }
}
