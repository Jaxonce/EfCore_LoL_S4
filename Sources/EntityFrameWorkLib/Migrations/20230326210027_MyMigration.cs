using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkLib.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Runes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    RuneFamily = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runes", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    SkillType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillEntityName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Champions_Skill_SkillEntityName",
                        column: x => x.SkillEntityName,
                        principalTable: "Skill",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "LargeImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Base64 = table.Column<string>(type: "TEXT", nullable: false),
                    championId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LargeImage_Champions_championId",
                        column: x => x.championId,
                        principalTable: "Champions",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RunesPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChampionEntityUniqueId = table.Column<int>(type: "INTEGER", nullable: true),
                    RuneEntityName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunesPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunesPage_Champions_ChampionEntityUniqueId",
                        column: x => x.ChampionEntityUniqueId,
                        principalTable: "Champions",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_RunesPage_Runes_RuneEntityName",
                        column: x => x.RuneEntityName,
                        principalTable: "Runes",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    ChampionEntityUniqueId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skins", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Skins_Champions_ChampionEntityUniqueId",
                        column: x => x.ChampionEntityUniqueId,
                        principalTable: "Champions",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champions_SkillEntityName",
                table: "Champions",
                column: "SkillEntityName");

            migrationBuilder.CreateIndex(
                name: "IX_LargeImage_championId",
                table: "LargeImage",
                column: "championId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RunesPage_ChampionEntityUniqueId",
                table: "RunesPage",
                column: "ChampionEntityUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_RunesPage_RuneEntityName",
                table: "RunesPage",
                column: "RuneEntityName");

            migrationBuilder.CreateIndex(
                name: "IX_Skins_ChampionEntityUniqueId",
                table: "Skins",
                column: "ChampionEntityUniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LargeImage");

            migrationBuilder.DropTable(
                name: "RunesPage");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
