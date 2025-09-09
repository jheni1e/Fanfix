using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fanfix.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fanfics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fanfics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fanfics_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReadingLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReadingLists_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReadingListFanfic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FanficID = table.Column<int>(type: "int", nullable: false),
                    ReadingListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingListFanfic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReadingListFanfic_Fanfics_FanficID",
                        column: x => x.FanficID,
                        principalTable: "Fanfics",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReadingListFanfic_ReadingLists_ReadingListID",
                        column: x => x.ReadingListID,
                        principalTable: "ReadingLists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fanfics_CreatorID",
                table: "Fanfics",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListFanfic_FanficID",
                table: "ReadingListFanfic",
                column: "FanficID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingListFanfic_ReadingListID",
                table: "ReadingListFanfic",
                column: "ReadingListID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLists_UserID",
                table: "ReadingLists",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingListFanfic");

            migrationBuilder.DropTable(
                name: "Fanfics");

            migrationBuilder.DropTable(
                name: "ReadingLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
