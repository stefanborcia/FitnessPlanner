using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDayPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HydrationTimes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayPlans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayPlans");
        }
    }
}
