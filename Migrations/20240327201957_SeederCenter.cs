using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP2EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeederCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Centers",
                column: "Id",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
