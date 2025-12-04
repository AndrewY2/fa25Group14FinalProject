using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa25Group14FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class correctPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the legacy Phone column that no longer exists in the model
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate the Phone column if you ever roll back
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

    }
}

