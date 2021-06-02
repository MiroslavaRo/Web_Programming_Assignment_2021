using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Programming_Assignment_2021.Migrations
{
    public partial class ChangeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AvatarFile", "Email", "Message", "Password", "Username" },
                values: new object[] { 1, "flower.jpg", "katrin@gmail.com", null, "PaS_S", "_Cutie_34" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AvatarFile", "Email", "Message", "Password", "Username" },
                values: new object[] { 2, "beautiful.jpg", "lolita_hanta@gmail.com", null, "Ger34_", "LolitaKit" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Comment", "DateCreated", "DateModified", "Hashtag", "PhotoFile", "UserId" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.", new DateTime(2021, 6, 2, 5, 19, 5, 948, DateTimeKind.Local).AddTicks(2171), new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(2934), "#cute #cutie #kitty", "cute.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Comment", "DateCreated", "DateModified", "Hashtag", "PhotoFile", "UserId" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.", new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7323), new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7404), "#cute #happy", "flower.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Comment", "DateCreated", "DateModified", "Hashtag", "PhotoFile", "UserId" },
                values: new object[] { 3, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.", new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7729), new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7754), "#kitty", "beautiful.jpg", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
