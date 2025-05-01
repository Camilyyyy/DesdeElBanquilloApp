using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesdeElBanquilloApp.Migrations
{
    /// <inheritdoc />
    public partial class MigracionReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competition_FTeam_FTeamIdFTeam",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_Match_MatchId",
                table: "MatchPlayer");

            migrationBuilder.DropIndex(
                name: "IX_Competition_FTeamIdFTeam",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "FTeamIdFTeam",
                table: "Competition");

            migrationBuilder.AddColumn<int>(
                name: "idCountry",
                table: "FTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompetitionFTeam",
                columns: table => new
                {
                    CompetitionFteamidCompetition = table.Column<int>(type: "int", nullable: false),
                    CompetitionTeamsIdFTeam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionFTeam", x => new { x.CompetitionFteamidCompetition, x.CompetitionTeamsIdFTeam });
                    table.ForeignKey(
                        name: "FK_CompetitionFTeam_Competition_CompetitionFteamidCompetition",
                        column: x => x.CompetitionFteamidCompetition,
                        principalTable: "Competition",
                        principalColumn: "idCompetition",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionFTeam_FTeam_CompetitionTeamsIdFTeam",
                        column: x => x.CompetitionTeamsIdFTeam,
                        principalTable: "FTeam",
                        principalColumn: "IdFTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionFTeam_CompetitionTeamsIdFTeam",
                table: "CompetitionFTeam",
                column: "CompetitionTeamsIdFTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_Match_MatchId",
                table: "MatchPlayer",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "IdMatch",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_Match_MatchId",
                table: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "CompetitionFTeam");

            migrationBuilder.DropColumn(
                name: "idCountry",
                table: "FTeam");

            migrationBuilder.AddColumn<int>(
                name: "FTeamIdFTeam",
                table: "Competition",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competition_FTeamIdFTeam",
                table: "Competition",
                column: "FTeamIdFTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_FTeam_FTeamIdFTeam",
                table: "Competition",
                column: "FTeamIdFTeam",
                principalTable: "FTeam",
                principalColumn: "IdFTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_Match_MatchId",
                table: "MatchPlayer",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "IdMatch",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
