using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa25Group14FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddTimesPurchasedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesPurchased",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesPurchased",
                table: "Books");
        }
    }
}
