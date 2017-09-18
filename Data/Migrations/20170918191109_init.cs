using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOverflowing.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TagName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Userinos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    IsMod = table.Column<bool>(type: "bool", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userinos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<int>(type: "int4", nullable: false),
                    UserModelID = table.Column<int>(type: "int4", nullable: true),
                    VoteCount = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_Userinos_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Userinos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    QuestionID = table.Column<int>(type: "int4", nullable: false),
                    QuestionModelID = table.Column<int>(type: "int4", nullable: true),
                    UserID = table.Column<int>(type: "int4", nullable: false),
                    UserModelID = table.Column<int>(type: "int4", nullable: true),
                    VoteCount = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionModelID",
                        column: x => x.QuestionModelID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Userinos_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Userinos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestionID = table.Column<int>(type: "int4", nullable: false),
                    QuestionModelID = table.Column<int>(type: "int4", nullable: true),
                    TagID = table.Column<int>(type: "int4", nullable: false),
                    TagModelID = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Qties_Questions_QuestionModelID",
                        column: x => x.QuestionModelID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qties_Tags_TagModelID",
                        column: x => x.TagModelID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnswerID = table.Column<int>(type: "int4", nullable: false),
                    AnswerModelID = table.Column<int>(type: "int4", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    QuestionID = table.Column<int>(type: "int4", nullable: false),
                    QuestionModelID = table.Column<int>(type: "int4", nullable: true),
                    UserID = table.Column<int>(type: "int4", nullable: false),
                    UserModelID = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Answers_AnswerModelID",
                        column: x => x.AnswerModelID,
                        principalTable: "Answers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Questions_QuestionModelID",
                        column: x => x.QuestionModelID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Userinos_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Userinos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionModelID",
                table: "Answers",
                column: "QuestionModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserModelID",
                table: "Answers",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnswerModelID",
                table: "Comments",
                column: "AnswerModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuestionModelID",
                table: "Comments",
                column: "QuestionModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserModelID",
                table: "Comments",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Qties_QuestionModelID",
                table: "Qties",
                column: "QuestionModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Qties_TagModelID",
                table: "Qties",
                column: "TagModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserModelID",
                table: "Questions",
                column: "UserModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Qties");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Userinos");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
