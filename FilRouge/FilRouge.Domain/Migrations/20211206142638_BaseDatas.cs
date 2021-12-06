using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilRouge.Data.Migrations
{
    public partial class BaseDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Posts_PostId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Tag A", null, null },
                    { 2, "Tag B", null, null },
                    { 3, "Tag C", null, null },
                    { 4, "Tag D", null, null },
                    { 5, "Tag E", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarURI", "Email", "FirstName", "IsBlacklisted", "LastName", "RegisterAt", "Username" },
                values: new object[,]
                {
                    { 1, "http://avatar.com/jojo", "jotaro.cujoh@mail.com", "Jotaro", false, "Cujoh", new DateTime(2021, 12, 6, 15, 26, 37, 513, DateTimeKind.Local).AddTicks(9279), "Jojo" },
                    { 2, "http://avatar.com/jojogirl", "jotaro.cujoh.girl@mail.com", "Jolyne", true, "Cujoh", new DateTime(2021, 12, 6, 15, 26, 37, 516, DateTimeKind.Local).AddTicks(4195), "JojoGirl" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "EditedAt", "Score", "Title" },
                values: new object[] { 1, 1, "Post A content", new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(3902), new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(4343), 0, "Post A" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "EditedAt", "Score", "Title" },
                values: new object[] { 2, 2, "Post B content", new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(5161), new DateTime(2021, 12, 6, 15, 26, 37, 519, DateTimeKind.Local).AddTicks(5173), 666, "Post B" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "EditedAt", "PostId", "Score" },
                values: new object[,]
                {
                    { 1, 1, "Answer A", new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(3172), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(3481), 1, 0 },
                    { 2, 2, "Answer B", new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4392), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4403), 1, 0 },
                    { 3, 1, "Answer C", new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4407), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4409), 2, 0 },
                    { 4, 2, "Answer D", new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4412), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(4414), 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnswerId", "AuthorId", "Content", "CreatedAt", "EditedAt", "Score" },
                values: new object[,]
                {
                    { 1, 1, 1, "Comment A", new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(9321), new DateTime(2021, 12, 6, 15, 26, 37, 520, DateTimeKind.Local).AddTicks(9618), 0 },
                    { 2, 1, 2, "Comment B", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(518), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(530), 0 },
                    { 3, 2, 1, "Comment C", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(534), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(536), 0 },
                    { 4, 2, 2, "Comment D", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(539), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(541), 0 },
                    { 5, 3, 1, "Comment A", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(544), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(546), 0 },
                    { 6, 3, 2, "Comment B", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(549), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(551), 0 },
                    { 7, 4, 1, "Comment C", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(553), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(555), 0 },
                    { 8, 4, 2, "Comment D", new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(558), new DateTime(2021, 12, 6, 15, 26, 37, 521, DateTimeKind.Local).AddTicks(560), 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Posts_PostId",
                table: "Answers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Posts_PostId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Posts_PostId",
                table: "Answers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerId",
                table: "Comments",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
