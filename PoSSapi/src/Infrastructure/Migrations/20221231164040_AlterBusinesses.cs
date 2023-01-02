using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoSSapi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterBusinesses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Businesses_ManagerId",
                table: "Businesses",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_ManagerId",
                table: "Businesses",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Users_ManagerId",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_ManagerId",
                table: "Businesses");
        }
    }
}
