using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoSSapi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToBusinesses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Businesses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Businesses");
        }
    }
}
