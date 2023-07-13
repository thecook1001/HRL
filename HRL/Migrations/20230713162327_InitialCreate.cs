using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatenAnSps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllgemeinWatchDog = table.Column<bool>(type: "bit", nullable: false),
                    AllgemeinStoerungQuittieren = table.Column<bool>(type: "bit", nullable: false),
                    Auftraege0Art = table.Column<int>(type: "int", nullable: false),
                    Auftraege0LagerId = table.Column<int>(type: "int", nullable: false),
                    Auftraege0PositionXP = table.Column<int>(type: "int", nullable: false),
                    Auftraege0PositionYP = table.Column<int>(type: "int", nullable: false),
                    Auftraege0PositionZP = table.Column<int>(type: "int", nullable: false),
                    Auftraege0Gewicht = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatenAnSps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatenAnSpsHistorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllgemeinWatchDog = table.Column<bool>(type: "bit", nullable: false),
                    AllgemeinStoerungQuittieren = table.Column<bool>(type: "bit", nullable: false),
                    Auftraege0Art = table.Column<int>(type: "int", nullable: false),
                    Auftraege0LagerId = table.Column<int>(type: "int", nullable: false),
                    Auftraege0PositionXP = table.Column<int>(type: "int", nullable: false),
                    Auftraege0PositionYP = table.Column<int>(type: "int", nullable: false),
                    Auftraege0PositionZP = table.Column<int>(type: "int", nullable: false),
                    Auftraege0Gewicht = table.Column<double>(type: "float", nullable: false),
                    ZeitStempel = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatenAnSpsHistorie", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatenAnSps");

            migrationBuilder.DropTable(
                name: "DatenAnSpsHistorie");
        }
    }
}
