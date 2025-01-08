using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataIntegration.Migrations
{
    /// <inheritdoc />
    public partial class AddParametrUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseTwoFactorAuthentication",
                table: "User",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseTwoFactorAuthentication",
                table: "User");
        }
    }
}
