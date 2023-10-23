using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations;

/// <inheritdoc />
public partial class addGenre : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "GENRE",
            table: "MOVIES");

        _ = migrationBuilder.AddColumn<int>(
            name: "ID_GENRE",
            table: "MOVIES",
            type: "INT",
            nullable: false,
            defaultValue: 0);

        _ = migrationBuilder.CreateTable(
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
                _ = table.PrimaryKey("PK_GENRES", x => x.ID);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.CreateIndex(
            name: "IND_MOVIES_001",
            table: "MOVIES",
            column: "ID_GENRE");

        _ = migrationBuilder.CreateIndex(
            name: "IDX_GENRES_001",
            table: "GENRES",
            column: "ID",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IDX_GENRES_002",
            table: "GENRES",
            column: "NAME",
            unique: true);

        _ = migrationBuilder.AddForeignKey(
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
        _ = migrationBuilder.DropForeignKey(
            name: "FK_MOVIES_GENRES_001",
            table: "MOVIES");

        _ = migrationBuilder.DropTable(
            name: "GENRES");

        _ = migrationBuilder.DropIndex(
            name: "IND_MOVIES_001",
            table: "MOVIES");

        _ = migrationBuilder.DropColumn(
            name: "ID_GENRE",
            table: "MOVIES");

        _ = migrationBuilder.AddColumn<string>(
            name: "GENRE",
            table: "MOVIES",
            type: "varchar(45)",
            nullable: false,
            defaultValue: "")
            .Annotation("MySql:CharSet", "utf8mb4");
    }
}
