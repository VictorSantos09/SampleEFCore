using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MOVIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "varchar(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GENRE = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIES", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PEOPLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEOPLE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PEOPLE_MOVIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_PERSON = table.Column<int>(type: "INT", nullable: false),
                    ID_MOVIE = table.Column<int>(type: "INT", nullable: false),
                    DATE = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEOPLE_MOVIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEOPLE_MOVIES_MOVIES_002",
                        column: x => x.ID_MOVIE,
                        principalTable: "MOVIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEOPLE_MOVIES_PEOPLE_001",
                        column: x => x.ID_PERSON,
                        principalTable: "PEOPLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IDX_MOVIES_001",
                table: "MOVIES",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_MOVIES_002",
                table: "MOVIES",
                column: "TITLE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_001",
                table: "PEOPLE",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_PEOPLE_MOVIES_001",
                table: "PEOPLE_MOVIES",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IND_PEOPLE_MOVIES_001",
                table: "PEOPLE_MOVIES",
                column: "ID_PERSON");

            migrationBuilder.CreateIndex(
                name: "IND_PEOPLE_MOVIES_002",
                table: "PEOPLE_MOVIES",
                column: "ID_MOVIE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEOPLE_MOVIES");

            migrationBuilder.DropTable(
                name: "MOVIES");

            migrationBuilder.DropTable(
                name: "PEOPLE");
        }
    }
}
