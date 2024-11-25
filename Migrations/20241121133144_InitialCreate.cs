using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XXMountainBrigadeNew.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CoyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CoyId);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seniority = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.RankId);
                });

            migrationBuilder.CreateTable(
                name: "UsersTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersId = table.Column<int>(type: "int", nullable: false),
                    CoyId = table.Column<int>(type: "int", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    CoyNameCoyId = table.Column<int>(type: "int", nullable: true),
                    RankNameRankId = table.Column<int>(type: "int", nullable: true),
                    TypeOfPersonnel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PersonnelNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnels_Companies_CoyId",
                        column: x => x.CoyId,
                        principalTable: "Companies",
                        principalColumn: "CoyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Companies_CoyNameCoyId",
                        column: x => x.CoyNameCoyId,
                        principalTable: "Companies",
                        principalColumn: "CoyId");
                    table.ForeignKey(
                        name: "FK_Personnels_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "RankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Ranks_RankNameRankId",
                        column: x => x.RankNameRankId,
                        principalTable: "Ranks",
                        principalColumn: "RankId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_CoyId",
                table: "Personnels",
                column: "CoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_CoyNameCoyId",
                table: "Personnels",
                column: "CoyNameCoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_RankId",
                table: "Personnels",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_RankNameRankId",
                table: "Personnels",
                column: "RankNameRankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataProtectionKey");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "UsersTbl");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
