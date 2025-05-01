using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesdeElBanquilloApp.Migrations
{
    /// <inheritdoc />
    public partial class Migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Federation",
                columns: table => new
                {
                    idFederation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federation", x => x.idFederation);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    IdPosition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.IdPosition);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    idCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    idFederation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.idCountry);
                    table.ForeignKey(
                        name: "FK_Country_Federation_idFederation",
                        column: x => x.idFederation,
                        principalTable: "Federation",
                        principalColumn: "idFederation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FTeam",
                columns: table => new
                {
                    IdFTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryidCountry = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTeam", x => x.IdFTeam);
                    table.ForeignKey(
                        name: "FK_FTeam_Country_CountryidCountry",
                        column: x => x.CountryidCountry,
                        principalTable: "Country",
                        principalColumn: "idCountry");
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    idCompetition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CompetitionStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CompetitionEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    idFederation = table.Column<int>(type: "int", nullable: false),
                    FederationidFederation = table.Column<int>(type: "int", nullable: true),
                    FTeamIdFTeam = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.idCompetition);
                    table.ForeignKey(
                        name: "FK_Competition_FTeam_FTeamIdFTeam",
                        column: x => x.FTeamIdFTeam,
                        principalTable: "FTeam",
                        principalColumn: "IdFTeam");
                    table.ForeignKey(
                        name: "FK_Competition_Federation_FederationidFederation",
                        column: x => x.FederationidFederation,
                        principalTable: "Federation",
                        principalColumn: "idFederation");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    idCountry = table.Column<int>(type: "int", nullable: false),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    idPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.IdPlayer);
                    table.ForeignKey(
                        name: "FK_Player_Country_idCountry",
                        column: x => x.idCountry,
                        principalTable: "Country",
                        principalColumn: "idCountry",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_FTeam_idTeam",
                        column: x => x.idTeam,
                        principalTable: "FTeam",
                        principalColumn: "IdFTeam",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Position_idPosition",
                        column: x => x.idPosition,
                        principalTable: "Position",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    IdMatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMatch = table.Column<bool>(type: "bit", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    CompetitionidCompetition = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.IdMatch);
                    table.ForeignKey(
                        name: "FK_Match_Competition_CompetitionidCompetition",
                        column: x => x.CompetitionidCompetition,
                        principalTable: "Competition",
                        principalColumn: "idCompetition");
                    table.ForeignKey(
                        name: "FK_Match_FTeam_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "FTeam",
                        principalColumn: "IdFTeam",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_FTeam_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "FTeam",
                        principalColumn: "IdFTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    IsStarter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "IdMatch",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competition_FederationidFederation",
                table: "Competition",
                column: "FederationidFederation");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_FTeamIdFTeam",
                table: "Competition",
                column: "FTeamIdFTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Country_idFederation",
                table: "Country",
                column: "idFederation");

            migrationBuilder.CreateIndex(
                name: "IX_FTeam_CountryidCountry",
                table: "FTeam",
                column: "CountryidCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamId",
                table: "Match",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_CompetitionidCompetition",
                table: "Match",
                column: "CompetitionidCompetition");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_MatchId_PlayerId",
                table: "MatchPlayer",
                columns: new[] { "MatchId", "PlayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PlayerId",
                table: "MatchPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PositionId",
                table: "MatchPlayer",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_idCountry",
                table: "Player",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Player_idPosition",
                table: "Player",
                column: "idPosition");

            migrationBuilder.CreateIndex(
                name: "IX_Player_idTeam",
                table: "Player",
                column: "idTeam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "FTeam");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Federation");
        }
    }
}
