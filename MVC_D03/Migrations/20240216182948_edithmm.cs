using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_D03.Migrations
{
    /// <inheritdoc />
    public partial class edithmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Department");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
