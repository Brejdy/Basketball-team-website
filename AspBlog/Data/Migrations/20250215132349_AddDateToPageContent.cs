using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToPageContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PageContent",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropColumn(
                name: "Date",
                table: "PageContent");
        }
    }
}
