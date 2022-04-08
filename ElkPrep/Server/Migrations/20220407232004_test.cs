using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElkPrep.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "arrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fletch = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arrows_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "bows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DrawWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LetOff = table.Column<int>(type: "int", nullable: false),
                    FPS = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    ArrowId = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bows_arrows_ArrowId",
                        column: x => x.ArrowId,
                        principalTable: "arrows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_bows_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Broadhead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Blades = table.Column<int>(type: "int", nullable: false),
                    ArrowId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadhead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Broadhead_arrows_ArrowId",
                        column: x => x.ArrowId,
                        principalTable: "arrows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Broadhead_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vital = table.Column<bool>(type: "bit", nullable: false),
                    PointValue = table.Column<int>(type: "int", nullable: false),
                    ArrowId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shot_arrows_ArrowId",
                        column: x => x.ArrowId,
                        principalTable: "arrows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shot_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitalSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    ShotId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Target_Shot_ShotId",
                        column: x => x.ShotId,
                        principalTable: "Shot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Target_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_arrows_UserId",
                table: "arrows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_bows_ArrowId",
                table: "bows",
                column: "ArrowId");

            migrationBuilder.CreateIndex(
                name: "IX_bows_UserId",
                table: "bows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Broadhead_ArrowId",
                table: "Broadhead",
                column: "ArrowId");

            migrationBuilder.CreateIndex(
                name: "IX_Broadhead_UserId",
                table: "Broadhead",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shot_ArrowId",
                table: "Shot",
                column: "ArrowId");

            migrationBuilder.CreateIndex(
                name: "IX_Shot_UserId",
                table: "Shot",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Target_ShotId",
                table: "Target",
                column: "ShotId");

            migrationBuilder.CreateIndex(
                name: "IX_Target_UserId",
                table: "Target",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bows");

            migrationBuilder.DropTable(
                name: "Broadhead");

            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.DropTable(
                name: "Shot");

            migrationBuilder.DropTable(
                name: "arrows");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
