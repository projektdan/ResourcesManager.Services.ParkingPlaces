using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResourcesManager.Services.ParkingPlaces.Api.Migrations
{
    public partial class AddLocationResourceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resources",
                schema: "ResourceManager.Reservation",
                table: "Locations");

            migrationBuilder.CreateTable(
                name: "LocationResources",
                schema: "ResourceManager.Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceQuantity = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now() at time zone 'utc'"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationResources", x => x.Id);
                    table.UniqueConstraint("AK_LocationResources_LocationId_ResourceId", x => new { x.LocationId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_LocationResources_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "ResourceManager.Reservation",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "ResourceManager.Reservation",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationResources_ResourceId",
                schema: "ResourceManager.Reservation",
                table: "LocationResources",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationResources",
                schema: "ResourceManager.Reservation");

            migrationBuilder.AddColumn<string>(
                name: "Resources",
                schema: "ResourceManager.Reservation",
                table: "Locations",
                type: "text",
                nullable: true);
        }
    }
}
