using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataIntegration.Migrations
{
    /// <inheritdoc />
    public partial class VersionProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canvas_User",
                table: "Canvas");

            migrationBuilder.DropIndex(
                name: "IX_Canvas_IdAuthor",
                table: "Canvas");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Canvas");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "Canvas",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "Canvas",
                newName: "MainVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Canvas_IdStatus",
                table: "Canvas",
                newName: "IX_Canvas_StatusId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Canvas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VersionsProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ParentOfVersionId = table.Column<int>(type: "int", nullable: false),
                    AuthorOfVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionsProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersionProject_User",
                        column: x => x.AuthorOfVersionId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VersionProject_VersionProject",
                        column: x => x.ParentOfVersionId,
                        principalTable: "VersionsProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canvas_AuthorId",
                table: "Canvas",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Canvas_MainVersionId",
                table: "Canvas",
                column: "MainVersionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersionsProjects_AuthorOfVersionId",
                table: "VersionsProjects",
                column: "AuthorOfVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionsProjects_ParentOfVersionId",
                table: "VersionsProjects",
                column: "ParentOfVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Canvas_User",
                table: "Canvas",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Canvas_VersionProject",
                table: "Canvas",
                column: "MainVersionId",
                principalTable: "VersionsProjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canvas_User",
                table: "Canvas");

            migrationBuilder.DropForeignKey(
                name: "FK_Canvas_VersionProject",
                table: "Canvas");

            migrationBuilder.DropTable(
                name: "VersionsProjects");

            migrationBuilder.DropIndex(
                name: "IX_Canvas_AuthorId",
                table: "Canvas");

            migrationBuilder.DropIndex(
                name: "IX_Canvas_MainVersionId",
                table: "Canvas");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Canvas");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Canvas",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "MainVersionId",
                table: "Canvas",
                newName: "IdAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Canvas_StatusId",
                table: "Canvas",
                newName: "IX_Canvas_IdStatus");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Canvas",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Canvas_IdAuthor",
                table: "Canvas",
                column: "IdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_Canvas_User",
                table: "Canvas",
                column: "IdAuthor",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
