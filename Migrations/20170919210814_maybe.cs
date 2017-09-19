using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOverflowing.Migrations
{
    public partial class maybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerModelID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionModelID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnswerID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionModelID",
                table: "Comments",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerModelID",
                table: "Comments",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerModelID",
                table: "Comments",
                column: "AnswerModelID",
                principalTable: "Answers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionModelID",
                table: "Comments",
                column: "QuestionModelID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerModelID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionModelID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionModelID",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerModelID",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AddColumn<int>(
                name: "AnswerID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerModelID",
                table: "Comments",
                column: "AnswerModelID",
                principalTable: "Answers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionModelID",
                table: "Comments",
                column: "QuestionModelID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
