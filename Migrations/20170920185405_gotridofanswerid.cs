using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOverflowing.Migrations
{
    public partial class gotridofanswerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answers_AnswerModelID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnswerModelID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnswerModelID",
                table: "Comments",
                column: "AnswerModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answers_AnswerModelID",
                table: "Comments",
                column: "AnswerModelID",
                principalTable: "Answers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
