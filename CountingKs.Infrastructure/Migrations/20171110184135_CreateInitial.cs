using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CountingKs.Infrastructure.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "FoodDiaries");

            migrationBuilder.EnsureSchema(
                name: "Nutrition");

            migrationBuilder.CreateTable(
                name: "Diary",
                schema: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                schema: "Nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiUser",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measure",
                schema: "Nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Cholestrol = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Iron = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    SaturatedFat = table.Column<double>(type: "float", nullable: false),
                    Sodium = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    TotalFat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measure_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "Nutrition",
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthToken",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApiUserId = table.Column<int>(type: "int", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthToken_ApiUser_ApiUserId",
                        column: x => x.ApiUserId,
                        principalSchema: "Security",
                        principalTable: "ApiUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryEntry",
                schema: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DairyId = table.Column<int>(type: "int", nullable: false),
                    DiaryId = table.Column<int>(type: "int", nullable: true),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    MesatureId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryEntry_Diary_DiaryId",
                        column: x => x.DiaryId,
                        principalSchema: "FoodDiaries",
                        principalTable: "Diary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiaryEntry_Food_FoodItemId",
                        column: x => x.FoodItemId,
                        principalSchema: "Nutrition",
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaryEntry_Measure_MeasureId",
                        column: x => x.MeasureId,
                        principalSchema: "Nutrition",
                        principalTable: "Measure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_DiaryId",
                schema: "FoodDiaries",
                table: "DiaryEntry",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_FoodItemId",
                schema: "FoodDiaries",
                table: "DiaryEntry",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_MeasureId",
                schema: "FoodDiaries",
                table: "DiaryEntry",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Measure_FoodId",
                schema: "Nutrition",
                table: "Measure",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthToken_ApiUserId",
                schema: "Security",
                table: "AuthToken",
                column: "ApiUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntry",
                schema: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "AuthToken",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Diary",
                schema: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "Measure",
                schema: "Nutrition");

            migrationBuilder.DropTable(
                name: "ApiUser",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Food",
                schema: "Nutrition");
        }
    }
}
