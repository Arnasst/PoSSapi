using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoSSapi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompletionTime",
                table: "Payments",
                newName: "TimeWhenCompleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeWhenCompleted",
                table: "Payments",
                newName: "CompletionTime");
        }
    }
}
