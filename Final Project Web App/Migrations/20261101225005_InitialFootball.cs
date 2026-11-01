using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final_Project_Web_App.Migrations
{
    /// <inheritdoc />
    public partial class InitialFootball : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    conferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.conferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    divisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    divisionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.divisionId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    divisionId = table.Column<int>(type: "int", nullable: true),
                    conferenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Conferences_conferenceId",
                        column: x => x.conferenceId,
                        principalTable: "Conferences",
                        principalColumn: "conferenceId");
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "divisionId");
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "conferenceId", "ConferenceName" },
                values: new object[,]
                {
                    { 1, "AFC" },
                    { 2, "NFC" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "divisionId", "divisionName" },
                values: new object[,]
                {
                    { 1, "North" },
                    { 2, "East" },
                    { 3, "South" },
                    { 4, "West" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "TeamName", "conferenceId", "divisionId" },
                values: new object[,]
                {
                    { 1, "Baltimore Ravens", 1, 1 },
                    { 2, "Cincinnati Bengals", 1, 1 },
                    { 3, "Cleveland Browns", 1, 1 },
                    { 4, "Pittsburgh Steelers", 1, 1 },
                    { 5, "Buffalo Bills", 1, 2 },
                    { 6, "New England Patriots", 1, 2 },
                    { 7, "New York Jets", 1, 2 },
                    { 8, "Miami Dolphins", 1, 2 },
                    { 9, "Houston Texans", 1, 3 },
                    { 10, "Jacksonville Jaguars", 1, 3 },
                    { 11, "Tennessee Titans", 1, 3 },
                    { 12, "Indianapolis Colts", 1, 3 },
                    { 13, "Denver Broncos", 1, 4 },
                    { 14, "Kansas City Chiefs", 1, 4 },
                    { 15, "LA Chargers", 1, 4 },
                    { 16, "Las Vegas Raiders", 1, 4 },
                    { 17, "Chicago Bears", 2, 1 },
                    { 18, "Detroit Lions", 2, 1 },
                    { 19, "Green Bay Packers", 2, 1 },
                    { 20, "Minnesota Vikings", 2, 1 },
                    { 21, "New York Giants", 2, 2 },
                    { 22, "Philadelphia Eagles", 2, 2 },
                    { 23, "Washington Commanders", 2, 2 },
                    { 24, "Dallas Cowboys", 2, 2 },
                    { 25, "Atlanta Falcons", 2, 3 },
                    { 26, "Carolina Panthers", 2, 3 },
                    { 27, "New Orleans Saints", 2, 3 },
                    { 28, "Tampa Bay Buccaneers", 2, 3 },
                    { 29, "Arizona Cardinals", 2, 4 },
                    { 30, "Los Angeles Rams", 2, 4 },
                    { 31, "San Francisco 49ers", 2, 4 },
                    { 32, "Seattle Seahawks", 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_conferenceId",
                table: "Teams",
                column: "conferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_divisionId",
                table: "Teams",
                column: "divisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Divisions");
        }
    }
}
