﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DatingApp.API.Migrations
{
    public partial class fixedColumnNameCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Photos");
            migrationBuilder.CreateTable(
            name: "Photos",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Url = table.Column<string>(nullable: true),
                Description = table.Column<string>(nullable: true),
                DateAdded = table.Column<DateTime>(nullable: false),
                isMain = table.Column<bool>(nullable: false),
                UserId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Photos", x => x.Id);
                table.ForeignKey(
                    name: "FK_Photos_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
