using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataIntegration.Migrations
{
    /// <inheritdoc />
    public partial class Likes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikeOfCanvas",
                columns: table => new
                {
                    CanvasId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeOfCanvas", x => new { x.UserId, x.CanvasId });
                    table.ForeignKey(
                        name: "FK_LikeOfCanvas_Canvas_CanvasId",
                        column: x => x.CanvasId,
                        principalTable: "Canvas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeOfCanvas_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeOfCanvas_CanvasId",
                table: "LikeOfCanvas",
                column: "CanvasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeOfCanvas");
        }
    }
}
