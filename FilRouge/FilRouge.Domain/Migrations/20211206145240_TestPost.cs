using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilRouge.Data.Migrations
{
    public partial class TestPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(293), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(1836), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(1850), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(1852) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(1855), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(7452), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9268), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9283), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9288), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9293), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9298), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9303), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9307), new DateTime(2021, 12, 6, 15, 52, 39, 980, DateTimeKind.Local).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 978, DateTimeKind.Local).AddTicks(8570), new DateTime(2021, 12, 6, 15, 52, 39, 978, DateTimeKind.Local).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 52, 39, 978, DateTimeKind.Local).AddTicks(9612), new DateTime(2021, 12, 6, 15, 52, 39, 978, DateTimeKind.Local).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterAt",
                value: new DateTime(2021, 12, 6, 15, 52, 39, 972, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterAt",
                value: new DateTime(2021, 12, 6, 15, 52, 39, 974, DateTimeKind.Local).AddTicks(7927));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(3172), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4392), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4407), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4409) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4412), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4414) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(9321), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(9618) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(518), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(534), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(539), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(544), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(549), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(553), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(558), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(3902), new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(4343) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(5161), new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterAt",
                value: new DateTime(2021, 12, 6, 15, 26, 37, 513, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterAt",
                value: new DateTime(2021, 12, 6, 15, 26, 37, 516, DateTimeKind.Local).AddTicks(4195));
        }
    }
}
