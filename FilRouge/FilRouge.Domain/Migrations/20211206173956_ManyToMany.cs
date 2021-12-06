using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilRouge.Data.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "TagUser",
                columns: table => new
                {
                    FavoriteTagsId = table.Column<int>(type: "int", nullable: false),
                    SubscribersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUser", x => new { x.FavoriteTagsId, x.SubscribersId });
                    table.ForeignKey(
                        name: "FK_TagUser_Tags_FavoriteTagsId",
                        column: x => x.FavoriteTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUser_Users_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(760), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(1982), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(1995) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(1998), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(2003), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(2005) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(8426), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(8724) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9618), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9634), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9640), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9642) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9644), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9649), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9651) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9654), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9659), new DateTime(2021, 12, 6, 18, 39, 55, 856, DateTimeKind.Local).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 855, DateTimeKind.Local).AddTicks(1195), new DateTime(2021, 12, 6, 18, 39, 55, 855, DateTimeKind.Local).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 39, 55, 855, DateTimeKind.Local).AddTicks(2369), new DateTime(2021, 12, 6, 18, 39, 55, 855, DateTimeKind.Local).AddTicks(2382) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterAt",
                value: new DateTime(2021, 12, 6, 18, 39, 55, 848, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterAt",
                value: new DateTime(2021, 12, 6, 18, 39, 55, 851, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.CreateIndex(
                name: "IX_TagUser_SubscribersId",
                table: "TagUser",
                column: "SubscribersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tags",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
