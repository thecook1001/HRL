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
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    TransportDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Art = table.Column<short>(type: "smallint", nullable: false),
                    LagerId = table.Column<short>(type: "smallint", nullable: false),
                    PositionXP = table.Column<short>(type: "smallint", nullable: false),
                    PositionYP = table.Column<short>(type: "smallint", nullable: false),
                    PositionZP = table.Column<short>(type: "smallint", nullable: false),
                    Gewicht = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
