using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXMountainBrigadeNew.Migrations
{
    /// <inheritdoc />
    public partial class AddRNameAndCNameCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Companies_CoyNameCoyId",
                table: "Personnels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Ranks_RankNameRankId",
                table: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Personnels_CoyNameCoyId",
                table: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Personnels_RankNameRankId",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "CoyNameCoyId",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "RankNameRankId",
                table: "Personnels");

            migrationBuilder.AddColumn<string>(
                name: "CoyName",
                table: "Personnels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RankName",
                table: "Personnels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoyName",
                table: "Personnels");

            migrationBuilder.DropColumn(
                name: "RankName",
                table: "Personnels");

            migrationBuilder.AddColumn<int>(
                name: "CoyNameCoyId",
                table: "Personnels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankNameRankId",
                table: "Personnels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_CoyNameCoyId",
                table: "Personnels",
                column: "CoyNameCoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_RankNameRankId",
                table: "Personnels",
                column: "RankNameRankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Companies_CoyNameCoyId",
                table: "Personnels",
                column: "CoyNameCoyId",
                principalTable: "Companies",
                principalColumn: "CoyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Ranks_RankNameRankId",
                table: "Personnels",
                column: "RankNameRankId",
                principalTable: "Ranks",
                principalColumn: "RankId");
        }
    }
}
