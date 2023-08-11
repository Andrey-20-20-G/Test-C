using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Test_C.Migrations
{
    /// <inheritdoc />
    public partial class IntialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drillBlock",
                columns: table => new
                {
                    DrillBlockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrillBlockName = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drillBlock", x => x.DrillBlockId);
                });

            migrationBuilder.CreateTable(
                name: "drillBlockPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrillBlockId = table.Column<int>(type: "integer", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Z = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drillBlockPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drillBlockPoints_drillBlock_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "drillBlock",
                        principalColumn: "DrillBlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hole",
                columns: table => new
                {
                    HoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrillBlockId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Depth = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hole", x => x.HoleId);
                    table.ForeignKey(
                        name: "FK_hole_drillBlock_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "drillBlock",
                        principalColumn: "DrillBlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "holePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoleId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Z = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_holePoints_hole_HoleId",
                        column: x => x.HoleId,
                        principalTable: "hole",
                        principalColumn: "HoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drillBlockPoints_DrillBlockId",
                table: "drillBlockPoints",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_hole_DrillBlockId",
                table: "hole",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_holePoints_HoleId",
                table: "holePoints",
                column: "HoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drillBlockPoints");

            migrationBuilder.DropTable(
                name: "holePoints");

            migrationBuilder.DropTable(
                name: "hole");

            migrationBuilder.DropTable(
                name: "drillBlock");
        }
    }
}
