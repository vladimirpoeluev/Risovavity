using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 250, nullable: false),
                    IdRole = table.Column<int>(type: "integer", nullable: false),
                    Icon = table.Column<byte[]>(type: "bytea", nullable: true),
                    UseTwoFactorAuthentication = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InteractiveCanvas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ConnectionString = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IdStatus = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractiveCanvas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractiveCanvas_Status",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InteractiveCanvas_User",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VersionsProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    ParentOfVersionId = table.Column<int>(type: "integer", nullable: true),
                    AuthorOfVersionId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Canvas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    MainVersionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canvas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canvas_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Canvas_User",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Canvas_VersionProject",
                        column: x => x.MainVersionId,
                        principalTable: "VersionsProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeOfVersionProject",
                columns: table => new
                {
                    VersionProjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LikeOfCanvas",
                columns: table => new
                {
                    CanvasId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_Canvas_AuthorId",
                table: "Canvas",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Canvas_MainVersionId",
                table: "Canvas",
                column: "MainVersionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Canvas_StatusId",
                table: "Canvas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractiveCanvas_Author",
                table: "InteractiveCanvas",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_InteractiveCanvas_IdStatus",
                table: "InteractiveCanvas",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_LikeOfCanvas_CanvasId",
                table: "LikeOfCanvas",
                column: "CanvasId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeOfVersionProject_UserId",
                table: "LikeOfVersionProject",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_VersionsProjects_AuthorOfVersionId",
                table: "VersionsProjects",
                column: "AuthorOfVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionsProjects_ParentOfVersionId",
                table: "VersionsProjects",
                column: "ParentOfVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteractiveCanvas");

            migrationBuilder.DropTable(
                name: "LikeOfCanvas");

            migrationBuilder.DropTable(
                name: "LikeOfVersionProject");

            migrationBuilder.DropTable(
                name: "Canvas");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "VersionsProjects");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
