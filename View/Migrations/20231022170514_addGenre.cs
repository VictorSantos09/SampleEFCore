using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations
{
    /// <inheritdoc />
    public partial class addGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GENRE",
                table: "MOVIES");

            migrationBuilder.AddColumn<int>(
                name: "ID_GENRE",
                table: "MOVIES",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GENRES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENRES", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IND_MOVIES_001",
                table: "MOVIES",
                column: "ID_GENRE");

            migrationBuilder.CreateIndex(
                name: "IDX_GENRES_001",
                table: "GENRES",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_GENRES_002",
                table: "GENRES",
                column: "NAME",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MOVIES_GENRES_001",
                table: "MOVIES",
                column: "ID_GENRE",
                principalTable: "GENRES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MOVIES_GENRES_001",
                table: "MOVIES");

            migrationBuilder.DropTable(
                name: "GENRES");

            migrationBuilder.DropIndex(
                name: "IND_MOVIES_001",
                table: "MOVIES");

            migrationBuilder.DropColumn(
                name: "ID_GENRE",
                table: "MOVIES");

            migrationBuilder.AddColumn<string>(
                name: "GENRE",
                table: "MOVIES",
                type: "varchar(45)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
