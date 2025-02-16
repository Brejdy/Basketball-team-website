﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Games : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oponent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cathegory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfGame = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
