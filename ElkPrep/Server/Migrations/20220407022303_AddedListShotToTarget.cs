using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElkPrep.Server.Migrations
{
    public partial class AddedListShotToTarget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    TargetId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Shot_Target_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Target",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shot_ArrowId",
                table: "Shot",
                column: "ArrowId");

            migrationBuilder.CreateIndex(
                name: "IX_Shot_TargetId",
                table: "Shot",
                column: "TargetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shot");
        }
    }
}
