using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImplementAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Subscription",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscription",
                table: "Users");
        }
    }
}
