using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDayPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "DayPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "DayPlans");
        }
    }
}
