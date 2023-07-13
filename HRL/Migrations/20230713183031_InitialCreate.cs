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
                name: "AllgemeinesVonSps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kommunikation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllgemeinesVonSps", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "FehlerlistenVonSps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    DatumUhrzeit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FehlerlistenVonSps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportmaschinenVonSps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SollPositionX = table.Column<float>(type: "real", nullable: false),
                    SollPositionY = table.Column<float>(type: "real", nullable: false),
                    SollPositionZ = table.Column<float>(type: "real", nullable: false),
                    SollPositionXP = table.Column<int>(type: "int", nullable: false),
                    SollPositionYP = table.Column<int>(type: "int", nullable: false),
                    SollPositionZP = table.Column<int>(type: "int", nullable: false),
                    IstPositionX = table.Column<float>(type: "real", nullable: false),
                    IstPositionY = table.Column<float>(type: "real", nullable: false),
                    IstPositionZ = table.Column<float>(type: "real", nullable: false),
                    IstPositionXP = table.Column<int>(type: "int", nullable: false),
                    IstPositionYP = table.Column<int>(type: "int", nullable: false),
                    IstPositionZP = table.Column<int>(type: "int", nullable: false),
                    Zustand = table.Column<int>(type: "int", nullable: false),
                    BelegungPhysisch = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportmaschinenVonSps", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllgemeinesVonSps");

            migrationBuilder.DropTable(
                name: "DatenAnSps");

            migrationBuilder.DropTable(
                name: "DatenAnSpsHistorie");

            migrationBuilder.DropTable(
                name: "FehlerlistenVonSps");

            migrationBuilder.DropTable(
                name: "TransportmaschinenVonSps");
        }
    }
}
