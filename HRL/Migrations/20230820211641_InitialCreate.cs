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
                name: "AllgemeinesAnSps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchDog = table.Column<bool>(type: "bit", nullable: false),
                    StoerungQuittieren = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllgemeinesAnSps", x => x.Id);
                });

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
                name: "AuftraegeAnSps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Art = table.Column<short>(type: "smallint", nullable: false),
                    LagerId = table.Column<short>(type: "smallint", nullable: false),
                    PositionXP = table.Column<short>(type: "smallint", nullable: false),
                    PositionYP = table.Column<short>(type: "smallint", nullable: false),
                    PositionZP = table.Column<short>(type: "smallint", nullable: false),
                    Gewicht = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuftraegeAnSps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuftraegeAnSpsHistorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Art = table.Column<short>(type: "smallint", nullable: false),
                    LagerId = table.Column<short>(type: "smallint", nullable: false),
                    PositionXP = table.Column<short>(type: "smallint", nullable: false),
                    PositionYP = table.Column<short>(type: "smallint", nullable: false),
                    PositionZP = table.Column<short>(type: "smallint", nullable: false),
                    Gewicht = table.Column<float>(type: "real", nullable: false),
                    ZeitStempel = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuftraegeAnSpsHistorie", x => x.Id);
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
                name: "FehlerLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meldung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumUhrzeit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FehlerLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockSpaceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportId = table.Column<short>(type: "smallint", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    PostingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransportUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSpaceData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportId = table.Column<short>(type: "smallint", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    PostingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransportUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSpaces", x => x.Id);
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
                name: "AllgemeinesAnSps");

            migrationBuilder.DropTable(
                name: "AllgemeinesVonSps");

            migrationBuilder.DropTable(
                name: "AuftraegeAnSps");

            migrationBuilder.DropTable(
                name: "AuftraegeAnSpsHistorie");

            migrationBuilder.DropTable(
                name: "FehlerlistenVonSps");

            migrationBuilder.DropTable(
                name: "FehlerLogs");

            migrationBuilder.DropTable(
                name: "StockSpaceData");

            migrationBuilder.DropTable(
                name: "StockSpaces");

            migrationBuilder.DropTable(
                name: "TransportmaschinenVonSps");
        }
    }
}
