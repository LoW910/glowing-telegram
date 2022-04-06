using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElkPrep.Server.Migrations
{
    public partial class AddedUsersBowsArrowsToElkPrepDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "arrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fletch = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Weight = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Length = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Broadhead = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arrows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DrawLength = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    DrawWeight = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    LetOff = table.Column<int>(type: "int", unicode: false, nullable: false),
                    FPS = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Range = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arrows");

            migrationBuilder.DropTable(
                name: "bows");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
