using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.DataAccess.Migrations
{
    public partial class AddRouteToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutgoingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Stations_DestinationStationId",
                        column: x => x.DestinationStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Stations_OutgoingStationId",
                        column: x => x.OutgoingStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestinationStationId",
                table: "Routes",
                column: "DestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_OutgoingStationId",
                table: "Routes",
                column: "OutgoingStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
