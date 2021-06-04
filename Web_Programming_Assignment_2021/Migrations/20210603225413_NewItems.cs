using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Programming_Assignment_2021.Migrations
{
    public partial class NewItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 4, 1, 54, 11, 364, DateTimeKind.Local).AddTicks(7744), new DateTime(2021, 6, 4, 1, 54, 11, 407, DateTimeKind.Local).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 4, 1, 54, 11, 408, DateTimeKind.Local).AddTicks(1538), new DateTime(2021, 6, 4, 1, 54, 11, 408, DateTimeKind.Local).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "Comment", "DateCreated", "DateModified" },
                values: new object[] { "Quisquam necessitatibus incidunt ut officiis explicabo inventore.", new DateTime(2021, 6, 4, 1, 54, 11, 408, DateTimeKind.Local).AddTicks(1862), new DateTime(2021, 6, 4, 1, 54, 11, 408, DateTimeKind.Local).AddTicks(1886) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Status",
                value: "Love my life 😍");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Status",
                value: "Artist/Illustrator/Commissions Opened 💖");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AvatarFile", "Email", "Message", "Password", "Status", "Username" },
                values: new object[] { 3, null, "thomasLi@gmail.com", null, "ToMik", null, "FunnyTom" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Comment", "DateCreated", "DateModified", "Hashtag", "PhotoFile", "UserId" },
                values: new object[] { 4, "Ipsum dolor sit amet consectetur adipisicing elit.", new DateTime(2021, 6, 4, 1, 54, 11, 408, DateTimeKind.Local).AddTicks(2008), new DateTime(2021, 6, 4, 1, 54, 11, 408, DateTimeKind.Local).AddTicks(2029), "#smile", "smile.jpg", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 3, 4, 22, 2, 21, DateTimeKind.Local).AddTicks(8168), new DateTime(2021, 6, 3, 4, 22, 2, 38, DateTimeKind.Local).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 3, 4, 22, 2, 39, DateTimeKind.Local).AddTicks(3271), new DateTime(2021, 6, 3, 4, 22, 2, 39, DateTimeKind.Local).AddTicks(3384) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "Comment", "DateCreated", "DateModified" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.", new DateTime(2021, 6, 3, 4, 22, 2, 39, DateTimeKind.Local).AddTicks(3643), new DateTime(2021, 6, 3, 4, 22, 2, 39, DateTimeKind.Local).AddTicks(3670) });
        }
    }
}
