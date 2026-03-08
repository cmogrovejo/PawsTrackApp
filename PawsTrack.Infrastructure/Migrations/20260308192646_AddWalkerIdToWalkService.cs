using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWalkerIdToWalkService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WalkerId",
                table: "WalkServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WalkServices_WalkerId",
                table: "WalkServices",
                column: "WalkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WalkServices_WalkerId",
                table: "WalkServices");

            migrationBuilder.DropColumn(
                name: "WalkerId",
                table: "WalkServices");
        }
    }
}
