using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP2EFCore.Migrations
{
    /// <inheritdoc />
    public partial class add_lowes_number_to_catrgories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LowestNumber",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowestNumber",
                table: "Categories");
        }
    }
}
