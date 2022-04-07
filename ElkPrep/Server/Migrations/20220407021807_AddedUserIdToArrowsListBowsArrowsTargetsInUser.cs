using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElkPrep.Server.Migrations
{
    public partial class AddedUserIdToArrowsListBowsArrowsTargetsInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "bows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BowId",
                table: "arrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "arrows",
                type: "int",
                nullable: true);

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
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Target_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bows_UserId",
                table: "bows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_arrows_UserId",
                table: "arrows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Target_UserId",
                table: "Target",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_arrows_users_UserId",
                table: "arrows",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bows_users_UserId",
                table: "bows",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_arrows_users_UserId",
                table: "arrows");

            migrationBuilder.DropForeignKey(
                name: "FK_bows_users_UserId",
                table: "bows");

            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.DropIndex(
                name: "IX_bows_UserId",
                table: "bows");

            migrationBuilder.DropIndex(
                name: "IX_arrows_UserId",
                table: "arrows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "bows");

            migrationBuilder.DropColumn(
                name: "BowId",
                table: "arrows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "arrows");
        }
    }
}
