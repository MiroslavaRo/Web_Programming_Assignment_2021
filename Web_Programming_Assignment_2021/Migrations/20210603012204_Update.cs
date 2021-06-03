using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Programming_Assignment_2021.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 3, 4, 22, 2, 39, DateTimeKind.Local).AddTicks(3643), new DateTime(2021, 6, 3, 4, 22, 2, 39, DateTimeKind.Local).AddTicks(3670) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 2, 5, 19, 5, 948, DateTimeKind.Local).AddTicks(2171), new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7323), new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7729), new DateTime(2021, 6, 2, 5, 19, 6, 61, DateTimeKind.Local).AddTicks(7754) });
        }
    }
}
