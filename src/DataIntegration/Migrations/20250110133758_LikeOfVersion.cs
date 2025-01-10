using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataIntegration.Migrations
{
    /// <inheritdoc />
    public partial class LikeOfVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikeOfVersionProject",
                columns: table => new
                {
                    VersionProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeOfVersionProject", x => new { x.VersionProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LikeOfVersionProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeOfVersionProject_VersionsProjects_VersionProjectId",
                        column: x => x.VersionProjectId,
                        principalTable: "VersionsProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeOfVersionProject_UserId",
                table: "LikeOfVersionProject",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeOfVersionProject");
        }
    }
}
