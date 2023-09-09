using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPOS.BlazorClient.Server.Migrations.EPOSDb
{
    /// <inheritdoc />
    public partial class CounterIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterId",
                table: "Orders");
        }
    }
}
